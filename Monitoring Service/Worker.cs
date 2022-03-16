using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FCC_SERVICE
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> logger;
        private readonly IHttpClientFactory httpClientFactory;
        private DBHelper dbHelper = new DBHelper();
        List<FCCModel> fccData = new List<FCCModel>();
        public static string Url = "https://opendata.usac.org/resource/nkde-wkir.json?$limit={lIMIT}&$offset={OFFSET}";
        public Worker(ILogger<Worker> logger, IHttpClientFactory httpClientFactory)
        {
            this.logger = logger;
            this.httpClientFactory = httpClientFactory;
            dbHelper = new DBHelper();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await fetchData();
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Error in Fetching Data");
                }
                finally
                {
                    DateTime currentTime = DateTime.Now;
                    DateTime nextExecution = currentTime.AddDays(7);
                    TimeSpan timeSpan = nextExecution.Subtract(currentTime);
                    int dueTime = Convert.ToInt32(timeSpan.TotalMilliseconds);
                    await Task.Delay(dueTime, stoppingToken);
                }
            }
        }

        private async Task fetchData()
        {
            fccData = new List<FCCModel>();
            int totalRecords = await getCount();
            logger.LogInformation("Data Fetching Inprogress.");
            int batchSize = 1000;
            int numberOfBatches = (int)Math.Ceiling((double)totalRecords / batchSize);
            var tasks = new List<Task>();
            for (int i = 0; i < numberOfBatches; i++)
            {
                var url = Url.Replace("{lIMIT}", batchSize.ToString()).Replace("{OFFSET}", (i * 1000).ToString());
                tasks.Add(fetchURLData(url));
                //await fetchURLData(url);
            }
            await Task.WhenAll(tasks);
            logger.LogInformation("Data Fetched SuccessFully.");
            logger.LogInformation("Data Saving Inprogress.");
            await saveData();
        }

        private async Task fetchURLData(string url)
        {
            try
            {
                var client = httpClientFactory.CreateClient();
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    List<FCCModel> apiData = JsonConvert.DeserializeObject<List<FCCModel>>(responseBody);
                    if (apiData != null && apiData.Count > 0)
                    {
                        fccData.AddRange(apiData);
                    }
                }
                else
                {
                    logger.LogInformation("Data Fetched Failed.", url);
                }
            }
            catch (Exception ex)
            {
                logger.LogInformation("Error Occured: " + ex.Message + " in " + url, url);
            }
        }

        private async Task<int> getCount()
        {
            try
            {
                logger.LogInformation("Getting Records Count");
                string CountURL = "https://opendata.usac.org/resource/nkde-wkir.json?$select=count(*)";
                var client = httpClientFactory.CreateClient();
                var response = await client.GetAsync(CountURL);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                   List<RecordsCount> count = JsonConvert.DeserializeObject<List<RecordsCount>>(responseBody);
                    if (count != null && count.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(count[0].count))
                        {

                            logger.LogInformation("Records Count is: "+ count[0].count);
                            return Convert.ToInt32(count[0].count);
                        }
                    }
                }               
               
            }
            catch (Exception ex)
            {
                logger.LogInformation("Error Occured While Getting Count: " + ex.Message);
            }
            return 0;
        }

        private async Task saveData()
        {
            try
            {
                bool result = await dbHelper.saveFCCData(fccData);
                if (result)
                    logger.LogInformation("Data Saved SuccessFully.");
                else
                    logger.LogInformation("Data Not Saved SuccessFully.");
            }
            catch (Exception ex)
            {
                logger.LogInformation("Error Occured While Saving Data: " + ex.Message);
            }
        }



    }
}

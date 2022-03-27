using FCC_SERVICE;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Monitoring_Service
{
  
    public class FCCDetailData
    {
        static readonly object Locker = new object();
        private readonly ILogger<Worker> logger;
        private readonly IHttpClientFactory httpClientFactory;
        private DBHelper dbHelper = new DBHelper();
        List<FCCDetailModel> fccData = new List<FCCDetailModel>();

        public FCCDetailData(ILogger<Worker> logger, IHttpClientFactory httpClientFactory)
        {
            this.logger = logger;
            this.httpClientFactory = httpClientFactory;
            dbHelper = new DBHelper();
        }

        public async Task fetchData(string Url)
        {
            fccData = new List<FCCDetailModel>();
            int totalRecords = await getCount();
            logger.LogInformation("Data Fetching Inprogress.");
            int batchSize = 1000;
            int numberOfBatches = (int)Math.Ceiling((double)totalRecords / batchSize);
            int BatchGroups= (int)Math.Ceiling((double)numberOfBatches / 20);
          
               var tasks = new List<Task>();
                for (int i=0; i < numberOfBatches; i++)
                {
                    var url = Url.Replace("{lIMIT}", batchSize.ToString()).Replace("{OFFSET}", (i * 1000).ToString());
                    //fetchURLData(url);
                    tasks.Add(fetchURLData(url));
                    
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
               // lock (Locker)
                {
                    var client = httpClientFactory.CreateClient();
                    var response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        List<FCCDetailModel> apiData = JsonConvert.DeserializeObject<List<FCCDetailModel>>(responseBody);
                        if (apiData != null && apiData.Count > 0)
                        {
                            fccData.AddRange(apiData);
                        }
                    }
                    else
                    {
                        logger.LogInformation("Data Fetched Failed. " + url, url+",  "+ response.RequestMessage);
                    }
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
                string CountURL = "https://opendata.usac.org/resource/i5j4-3rvr.json?$select=count(*)";
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

                            logger.LogInformation("Records Count is: " + count[0].count);
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
                logger.LogInformation("Records to be saved "+ fccData.Count);
                bool result = await dbHelper.saveData(fccData);
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

using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCC_SERVICE
{
    public class DBHelper
    {
        private ApplicationDBContext dbContext;

        private DbContextOptions<ApplicationDBContext> GetAllOptions()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
            optionBuilder.UseSqlServer(AppSettings.ConnectionString, sqlServerOptions => sqlServerOptions.CommandTimeout(60000));
            return optionBuilder.Options;
        }        

        public async Task<bool> saveData(List<FCCModel> fccData)
        {
            using (dbContext = new ApplicationDBContext(GetAllOptions()))
            {
                try
                {
                    fccData.RemoveAll(x => string.IsNullOrEmpty(x.AFundingRequestNumber));
                    fccData=fccData.GroupBy(x => x.AFundingRequestNumber).Select(r => r.Last()).ToList();
                    await dbContext.BulkInsertOrUpdateAsync(fccData);
                }
                catch (Exception exp)
                {
                    throw;
                   
                }
                return true;
            }


        }

        public async Task<bool> saveData(List<FCCDetailModel> fccData)
        {
            using (dbContext = new ApplicationDBContext(GetAllOptions()))
            {
                try
                {
                    fccData.ForEach(x => x.FormPdf = x.form_pdf?.url);
                    fccData.RemoveAll(x => string.IsNullOrEmpty(x.FundingRequestNumber));                  
                    fccData = fccData.GroupBy(x => x.FundingRequestNumber).Select(r => r.Last()).ToList();
                   
                    await dbContext.BulkInsertOrUpdateAsync(fccData);
                }
                catch (Exception exp)
                {
                    throw;

                }
                return true;
            }


        }
    }
}

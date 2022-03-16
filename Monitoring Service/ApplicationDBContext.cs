using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCC_SERVICE
{
    public class ApplicationDBContext : DbContext
    {
        protected ApplicationDBContext()
        {
        }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //if (!optionsBuilder.IsConfigured)
            //{
            //    // string connString = optionsBuilder.UseSqlServer(ConfigurationManager.[0].ConnectionString);
            //    string connString = "Server=DESKTOP-78RPD21;Database=FCC;Trusted_Connection=True;";
            //    optionsBuilder.UseSqlServer(connString);

            //}
        }
        public virtual DbSet<FCCModel> FCCModel { get; set; }

    }
}

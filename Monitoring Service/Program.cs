using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;

namespace FCC_SERVICE
{
    public class Program
    {

        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            CreateDatabaseIfNotExist(host);

            host.Run();
        }

        private static void CreateDatabaseIfNotExist(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ApplicationDBContext>();
                    context.Database.EnsureCreated();
                }
                catch (Exception exp)
                {

                    throw;
                }
            }
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)            
                .UseWindowsService()
                .UseSerilog()                
                .ConfigureServices((hostContext, services) =>
                {

                    IConfiguration configuration = hostContext.Configuration;
                    AppSettings.Configuration = configuration;
                    AppSettings.ConnectionString = configuration.GetConnectionString("DefaultConnection");

                    var optionBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
                    optionBuilder.UseSqlServer(AppSettings.ConnectionString,sqlServerOptions => sqlServerOptions.CommandTimeout(60000));

                    services.AddScoped<ApplicationDBContext>(d => new ApplicationDBContext(optionBuilder.Options));



                    Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(hostContext.Configuration).CreateLogger();
                    services.AddHttpClient();
                    services.AddHostedService<Worker>();
                });
    }
}

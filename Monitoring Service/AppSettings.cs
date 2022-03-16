using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCC_SERVICE
{
    public static class AppSettings
    {
        public static IConfiguration Configuration { get; set; }
        public static string ConnectionString { get; set; }
        //static string ConnctionString = "Server=DESKTOP-78RPD21;Database=FCC;Trusted_Connection=True;";
    }
}

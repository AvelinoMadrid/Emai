using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace EMAI.Helpers
{
    public class HelperConfiguration
    {

        public static AppConfiguration GetAppConfiguration(string configurationFile = "appsettings.json")
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile(configurationFile, optional: false)
                .Build();
            var result = configuration.Get<AppConfiguration>();
            return result;
        }






    }
}

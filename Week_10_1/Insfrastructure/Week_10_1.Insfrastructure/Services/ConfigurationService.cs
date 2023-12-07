using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Week_10_1.Infrastructure.Services
{
    public class ConfigurationService
    {
        private static ConfigurationService instance;
        private readonly IConfiguration configuration;

        private ConfigurationService()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            configuration = configurationBuilder.Build();
        }

        public static ConfigurationService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConfigurationService();
                }
                return instance;
            }
        }

        public string GetValue(string key)
        {
            return configuration[key];
        }
    }
}

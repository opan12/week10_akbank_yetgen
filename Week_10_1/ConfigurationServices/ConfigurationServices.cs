using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DessignPattern.Infrastructure.Services
{
    public class ConfigurationServices
    {
        private static ConfigurationServices instance;

        public static ConfigurationServices GetInstance()
        {

            if (instance == null)
                instance = new ConfigurationServices();

            return instance;
        }

        public string GetValue(string key)
        {
            ConfigurationManager configurationManager = new();

            string path = Directory.GetCurrentDirectory();

            configurationManager.SetBasePath(path);

            configurationManager.AddJsonFile("appsettings.json");

            return configurationManager.GetSection(key).Value;

        }

        ConfigurationServices()
        {
            Console.WriteLine("Instance Created");
        }
    }
}
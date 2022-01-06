using System.IO;
using Microsoft.Extensions.Configuration;

namespace Havan.Desafio.WebApi.Helpers
{
    public class ConfigurationHelper
    {
        public static string getConfigValue(string ConfigName)
        {
            try
            {
                return getConfigByDefault(ConfigName);
            }
            catch
            {
                return getConfigByWindowsServices(ConfigName);
            }
            
        }

        static string getConfigByDefault(string ConfigName)
        {

            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");    
        
            var config = builder.Build();
            
            string ConfigValue = string.Empty;

            if (config[ConfigName] != null)
                ConfigValue = config[ConfigName];

            return ConfigValue;

        }

        public static string getConfigByWindowsServices(string ConfigName)
        {
            string SystemPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location.ToString());
            
            var builder = new ConfigurationBuilder()
            .SetBasePath(SystemPath)
            .AddJsonFile("appsettings.json");    
        
            var config = builder.Build();
            
            string ConfigValue = string.Empty;

            if (config[ConfigName] != null)
                ConfigValue = config[ConfigName];

            return ConfigValue;

        }
    }
}
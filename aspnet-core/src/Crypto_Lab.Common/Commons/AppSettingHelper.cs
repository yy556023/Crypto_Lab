using Microsoft.Extensions.Configuration;

namespace Crypto_Lab.Common.Commons
{
    public class AppSettingHelper
    {
        public static IConfigurationSection GetSection(string sectionName)
        {
            // TODO: path 待完成
            string appsettingFileName = "appsettings.json";
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine($"{Directory.GetCurrentDirectory()}", appsettingFileName);
            configurationBuilder.AddJsonFile(path, false);
            var root = configurationBuilder.Build();
            return root.GetSection(sectionName);
        }
    }
}

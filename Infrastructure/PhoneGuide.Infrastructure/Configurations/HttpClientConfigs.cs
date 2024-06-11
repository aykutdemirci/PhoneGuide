using Microsoft.Extensions.Configuration;

namespace PhoneGuide.Infrastructure.Configurations
{
    public static class HttpClientConfigs
    {
        public static string ReportServiceBaseUrl
        {
            get
            {
                var cfgManager = new ConfigurationManager();
                cfgManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/PhoneGuide.API"));
                cfgManager.AddJsonFile("appsettings.json");

                return cfgManager.GetSection("HttpServices").GetSection("ReportService").GetSection("BaseUrl").Value;
            }
        }
    }
}

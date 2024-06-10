using Microsoft.Extensions.Configuration;

namespace PhoneGuide.Persistance.Configurations
{
    static class ConnectionStrings
    {
        public static string PostgreSQL
        {
            get
            {
                var cfgManager = new ConfigurationManager();
                cfgManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/PhoneGuide.API"));
                cfgManager.AddJsonFile("appsettings.json");
                return cfgManager.GetConnectionString("PostgreSQL");
            }
        }
    }
}

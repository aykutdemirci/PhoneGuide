using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PhoneGuide.Persistance.Configurations;
using PhoneGuide.Persistance.Contexts;

namespace PhoneGuide.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<PhoneGuideDbContext>(opts => opts.UseNpgsql(ConnectionStrings.PostgreSQL));
        }
    }
}

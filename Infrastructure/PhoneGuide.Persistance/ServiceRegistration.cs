using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PhoneGuide.Application.Abstractions.Services;
using PhoneGuide.Application.Abstractions.UnitOfWork;
using PhoneGuide.Application.Repositories;
using PhoneGuide.Persistance.Configurations;
using PhoneGuide.Persistance.Contexts;
using PhoneGuide.Persistance.Repositories;
using PhoneGuide.Persistance.Services;

namespace PhoneGuide.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<PhoneGuideDbContext>(opts => opts.UseNpgsql(ConnectionStrings.PostgreSQL));

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IReportService, ReportService>();
        }
    }
}

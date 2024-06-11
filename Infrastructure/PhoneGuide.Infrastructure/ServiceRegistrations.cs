using Microsoft.Extensions.DependencyInjection;
using PhoneGuide.Application.Abstractions.Caching;
using PhoneGuide.Application.Abstractions.HttpClient;
using PhoneGuide.Infrastructure.Enums;
using PhoneGuide.Infrastructure.Services;

namespace PhoneGuide.Infrastructure
{
    public static class ServiceRegistrations
    {
        public static void AddCache(this IServiceCollection serviceCollection, CachingType cachingType)
        {
            switch (cachingType)
            {
                case CachingType.InMemory:
                    serviceCollection.AddMemoryCache();
                    serviceCollection.AddScoped<ICacheService, InMemoryCacheService>();
                    break;
                case CachingType.Distributed:
                    //redis cache eklenebilir
                    break;
            }
        }

        public static void AddHttpClientService<T>(this IServiceCollection services) where T : class, IHttpClient
        {
            services.AddScoped<IHttpClient, T>();
        }
    }
}

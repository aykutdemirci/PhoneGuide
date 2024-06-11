using Microsoft.Extensions.DependencyInjection;
using PhoneGuide.Application.Abstractions.Caching;
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
    }
}

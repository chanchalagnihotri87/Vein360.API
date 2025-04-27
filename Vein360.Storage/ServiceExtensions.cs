using Microsoft.Extensions.DependencyInjection;
using Vein360.Application.Service.StorageService;
using Vein360.Storage.Service;

namespace Vein360.Shipment
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureStorage(this IServiceCollection services)
        {
            services.AddScoped<IStorageService, StorageService>();

            return services;
        }
    }
}

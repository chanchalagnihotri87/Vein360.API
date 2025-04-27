using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Service.ShipmentService;
using Vein360.Shipment.Service;

namespace Vein360.Shipment
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureShipment(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IShipmentService, ShipmentService>();

            FedexCredential fedexCredential = GetLoadedFedexCredential(configuration);

            services.AddSingleton(fedexCredential);



            return services;

            static FedexCredential GetLoadedFedexCredential(IConfiguration configuration)
            {
                var fedexCredential = new FedexCredential();
                configuration.GetSection("FedexCredential").Bind(fedexCredential);
                return fedexCredential;
            }
        }
    }
}

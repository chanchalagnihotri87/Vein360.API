using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Service.ShipmentService;
using Vein360.Application.Service.StorageService;
using Vein360.Shipment.Helper;
using Vein360.Shipment.Service;

namespace Vein360.Shipment
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureShipment(this IServiceCollection services, IConfiguration configuration, bool isDevelopment)
        {
            services.AddScoped<IShipmentService, ShipmentService>();

            services.AddScoped<IFedexAuthHelper, FedexAuthHelper>();

            services.AddScoped<IPickupService, PickupService>();


            FedexCredential fedexCredential = GetLoadedFedexCredential(configuration);

            services.AddSingleton(fedexCredential);


            ////VALIDATED ADDRESS THROWING ERROR ON PRODUCTION, USING LOCAL SERVICE FOR NOW
            //if (fedexCredential.ApiUrl.Contains("sandbox"))
            //{
            //    services.AddScoped<IAddressValidationService, LocalAddressValidationService>();
            //}
            //else
            //{
            //    services.AddScoped<IAddressValidationService, FedexAddressValidationService>();
            //}

            services.AddScoped<IAddressValidationService, LocalAddressValidationService>();


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

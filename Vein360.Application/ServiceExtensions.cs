using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using Vein360.Application.Service.ShipmentService;
using Vein360.Application.Features.Donations.Shared;

namespace Vein360.Application
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.AddScoped<IDonationShippingDetailHandler, DonationShippingDetailHandler>();

            return services;
        }

    }
}

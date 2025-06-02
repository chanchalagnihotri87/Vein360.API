using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Service.ReplenishmentService;
using Vein360.Replenishment.Service;

namespace Vein360.Replenishment
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureReplenishment(this IServiceCollection services)
        {
            return services.AddScoped<IReplenishmentService, ReplenishmentService>();
        }
    }
}

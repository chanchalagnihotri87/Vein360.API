using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository;
using Vein360.Application.Repository.ContainerRepository;
using Vein360.Application.Repository.DonationContainerRepository;
using Vein360.Application.Repository.DonationsRepository;
using Vein360.Application.Repository.ProductRepository;
using Vein360.Application.Repository.UserRepository;
using Vein360.Application.Repository.Vein360ContainerTypeRepository;
using Vein360.Persistence.Repository;
using Vein360.Persistence.Repository.ContainerRepository;
using Vein360.Persistence.Repository.DonationConatinerRepository;
using Vein360.Persistence.Repository.DonationRepository;
using Vein360.Persistence.Repository.ProductRepository;
using Vein360.Persistence.Repository.UserRepository;
using Vein360.Persistence.Repository.Vein360ContainerTypeRepository;


namespace Vein360.Persistence
{
    public static class PersistenceConfiguration
    {
        public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContextPool<Vein360Context>(options => options.UseSqlServer(configuration.GetConnectionString("Vein360Context")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDonationRepository, DonationRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IDonationContainerRepository, DonationContainerRepository>();
            services.AddScoped<IVein360ContainerTypeRepository, Vein360ContainerTypeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IContainerRepository, ContainerRepository>();
        }
    }
}

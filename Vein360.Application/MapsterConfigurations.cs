using Microsoft.Extensions.DependencyInjection;
using Vein360.Application.Features.DonationsFeatures.GetDonation;
using Vein360.Domain.Entities;

namespace Vein360.Application
{
    public static class MapsterConfigurations
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {
            TypeAdapterConfig<Clinic, ClinicDto>
           .NewConfig()
           .Map(dest => dest.ContactName, src => src.PrimaryContactName)
           .Map(dest => dest.ContactEmail, src => src.PrimaryContactEmail)
           .Map(dest => dest.ContactPhone, src => src.PrimaryContactPhone);
        }
    }
}

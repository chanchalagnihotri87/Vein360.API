using Microsoft.Extensions.DependencyInjection;
using Vein360.Application.Features.DonationsFeatures.GetDonation;
using Vein360.Domain.Entities;

namespace Vein360.Application
{
    public static class MapsterConfigurations
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {
            TypeAdapterConfig<Donation, GetDonationResponse>
                .NewConfig()
                .Map(dest => dest.ContainerId, src => src.ContainerType == ContainerType.FedexContainer ? src.FedexContainerId : src.DonationContainerId);

            TypeAdapterConfig<DonationContainer, DonationConatinerDto>
                .NewConfig()
                .Map(dest => dest.ContainerType, src => src.Container != null ? src.Container.ContainerType : src.ContainerType);
        }
    }
}

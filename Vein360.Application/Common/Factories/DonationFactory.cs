using Vein360.Domain.Entities;

namespace Vein360.Application.Common.Factories
{
    public class DonationFactory
    {
        public static Donation CreateDonation(ContainerType containerType, int? containerId, double? length, double? width, double? height, List<DonationProductItemDto> products, int userId)
        {
            return new Donation
            {
                ContainerType = containerType,
                DonationContainerId = containerType == ContainerType.Vein360Container ? containerId : null,
                FedexContainerId = containerType == ContainerType.FedexContainer ? containerId : null,
                Length = length,
                Width = width,
                Height = height,
                Status = DonationStatus.Donated,
                DonorId = userId,
                Products = products.Select(product => new DonationProduct { ProductId = product.ProductId, Units = product.Units }).ToHashSet(),
            };
        }
    }
}

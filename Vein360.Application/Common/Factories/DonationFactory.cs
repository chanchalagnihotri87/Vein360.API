using Vein360.Domain.Entities;

namespace Vein360.Application.Common.Factories
{
    public class DonationFactory
    {
        public static Donation CreateDonation(int clinicId, PackageType packingType, int? containerType, int? fedexPackagingType, long? trackingNumber, List<DonationProductItemDto> products, int userId)
        {
            return new Donation
            {
                ClinicId = clinicId,
                PackageType = packingType,
                ContainerTypeId = containerType,
                FedexPackagingTypeId = fedexPackagingType,
                TrackingNumber = trackingNumber,
                UseOldLabel = trackingNumber.HasValue,
                Status = DonationStatus.Donated,
                DonorId = userId,
                Products = products.Select(product => new DonationProduct { ProductId = product.ProductId, Units = product.Units }).ToHashSet(),
            };
        }
    }
}

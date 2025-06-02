using Vein360.Domain.Common;

namespace Vein360.Application.Service.ShipmentService
{
    public interface IShipmentService
    {
        Task<ShipmentDetailDto> CreateDonationShipmentAsync(PackageType packageType, int? fedexPackingType, double weight, IShippingAddress shippingAddress);
        Task<ShipmentDetailDto> CreateDonationContainerShipmentAsync(double weight);
        Task CancelShipmentAsync(long trackingNumber);
    }
}

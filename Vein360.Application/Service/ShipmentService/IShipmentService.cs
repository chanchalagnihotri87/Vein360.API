using Vein360.Domain.Common;

namespace Vein360.Application.Service.ShipmentService
{
    public interface IShipmentService
    {
        Task<ShipmentDetailDto> CreateDonationShipmentAsync(double weight, IShippingAddress shippingAddress);
        Task CancelShipmentAsync(long trackingNumber);
    }
}

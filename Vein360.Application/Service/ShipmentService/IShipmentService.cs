namespace Vein360.Application.Service.ShipmentService
{
    public interface IShipmentService
    {
        Task<ShipmentDetailDto> CreateDonationShipmentAsync(ContainerType containerType, int? containerId, double weight);
        Task<ShipmentDetailDto> CreateDonationContainerShipmentAsync(double weight);
        Task CancelShipmentAsync(long trackingNumber);
    }
}

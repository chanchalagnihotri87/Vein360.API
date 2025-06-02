namespace Vein360.Application.Features.Donations.CreateDonation
{
    public record CreateDonationRequest : IRequest
    {
        public int ClinicId { get; set; }
        public PackageType PackageType { get; set; }
        public int? ContainerTypeId { get; set; }
        public int? FedexPackagingTypeId { get; set; }
        public long? TrackingNumber { get; set; }
        public List<DonationProductItemDto> Products { get; set; }
    }
}

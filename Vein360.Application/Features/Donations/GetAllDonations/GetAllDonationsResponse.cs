namespace Vein360.Application.Features.DonationsFeatures.GetAllDonations
{
    public sealed record GetAllDonationsResponse
    {
        public int Id { get; set; }
        public PackageType PackageType { get; set; }
        public int? ContainerTypeId { get; set; }
        public int? FedexPackagingTypeId { get; set; }
        public List<string> ProductTypes { get; set; }
        public long? TrackingNumber { get; set; }
        public string? LabelFileName { get; set; }
        public DonationStatus Status { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}

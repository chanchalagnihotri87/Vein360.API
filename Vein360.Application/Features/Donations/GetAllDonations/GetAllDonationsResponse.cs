namespace Vein360.Application.Features.DonationsFeatures.GetAllDonations
{
    public sealed record GetAllDonationsResponse
    {
        public int Id { get; set; }
        public int ContainerId { get; set; }
        public ContainerType ContainerType { get; set; }
        public List<string> ProductTypes { get; set; }
        public long? TrackingNumber { get; set; }
        public string? LabelFileName { get; set; }
        public DonationStatus Status { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}

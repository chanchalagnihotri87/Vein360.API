namespace Vein360.Application.Features.DonationsFeatures.GetDonation
{
    public record GetDonationResponse
    {
        public int Id { get; set; }
        public ContainerType ContainerType { get; set; }       
        public int ContainerId { get; set; }
        public double? Length { get; set; } //in inches
        public double? Width { get; set; } //in inches
        public double? Height { get; set; } //in inches
        public long? TrackingNumber { get; set; }
        public DonationConatinerDto Container { get; set; }
        public ICollection<DonationProductDto> Products { get; set; }
    }
}

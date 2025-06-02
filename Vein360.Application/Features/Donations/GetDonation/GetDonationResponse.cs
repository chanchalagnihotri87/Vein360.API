namespace Vein360.Application.Features.DonationsFeatures.GetDonation
{
    public record GetDonationResponse
    {
        public int Id { get; set; }
        public int ClinicId { get; set; }
        public PackageType PackageType { get; set; }       
        public int? ContainerTypeId { get; set; }
        public int? FedexPackagingTypeId { get; set; }
        public long? TrackingNumber { get; set; }
        public bool UseOldLabel { get; set; }
        public double Amount { get; set; }

        public ClinicDto Clinic { get; set; }
        public ContainerTypeDto ContainerType { get; set; }
        public ICollection<DonationProductDto> Products { get; set; }
    }
}

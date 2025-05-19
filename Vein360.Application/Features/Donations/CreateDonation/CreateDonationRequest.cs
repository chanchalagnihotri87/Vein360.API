namespace Vein360.Application.Features.Donations.CreateDonation
{
    public record CreateDonationRequest : IRequest
    {
        public ContainerType ContainerType { get; set; }
        public int? ContainerId { get; set; }
        public double? length { get; set; } // in inches
        public double? width { get; set; } // in inches
        public double? height { get; set; } // in inches
        public List<DonationProductItemDto> Products { get; set; }
    }
}

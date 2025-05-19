using Vein360.Application.Features.DonationsFeatures.GetAllDonations;

namespace Vein360.Application.Features.Donations.UpdateDonation
{
    public record UpdateDonationRequest : IRequest<GetAllDonationsResponse>
    {
        public int Id { get; set; }
        public ContainerType ContainerType { get; set; }
        public int? ContainerId { get; set; }
        public double? length { get; set; } // in inches
        public double? width { get; set; } // in inches
        public double? height { get; set; } // in inches
        public List<DonationProductDto> Products { get; set; }
    }
}

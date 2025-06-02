using Vein360.Application.Features.DonationsFeatures.GetAllDonations;

namespace Vein360.Application.Features.Donations.UpdateDonation
{
    public record UpdateDonationRequest : IRequest<GetAllDonationsResponse>
    {
        public int Id { get; set; }
        public double Amount { get; set; }

    }
}

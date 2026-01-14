using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Features.DonationsFeatures.GetDonorDonations;

namespace Vein360.Application.Features.Donations.ReschedulePickup
{
    public record RescheduleDonationPickupRequest(int DonationId) : IRequest<GetDonorDonationsResponse>
    {
    }
}

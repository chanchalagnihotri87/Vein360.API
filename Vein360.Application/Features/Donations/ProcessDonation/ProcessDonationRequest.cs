using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Features.DonationsFeatures.GetAllDonations;

namespace Vein360.Application.Features.Donations.ProcessDonation
{
   public record ProcessDonationRequest(int DonationId, List<ProcessedProductDto> Products): IRequest<GetAllDonationsResponse>
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.Donations.SortDonation
{
    public record SortDonationRequest(long ContainerId, List<SortedDonationProductDto> Products, double TotalAmount) : IRequest
    {
    }
}

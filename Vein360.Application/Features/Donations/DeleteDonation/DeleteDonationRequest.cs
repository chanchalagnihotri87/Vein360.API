using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.Donations.DeleteDonation
{
    public class DeleteDonationRequest: IRequest
    {
        public int DonationId { get; set; }
    }
}

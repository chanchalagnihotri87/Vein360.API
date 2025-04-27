using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.DonationsFeatures.GetDonation
{
    public record GetDonationRequest : IRequest<GetDonationResponse>
    {
        public int Id { get; set; }
    }

}

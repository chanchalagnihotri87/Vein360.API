using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.DonationsFeatures.GetAllDonations
{
    public sealed record GetAllDonationsRequest: IRequest<List<GetAllDonationsResponse>>
    {
    }
}

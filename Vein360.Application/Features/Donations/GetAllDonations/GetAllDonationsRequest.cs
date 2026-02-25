using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.DonationsFeatures.GetAllDonations
{
    public sealed record GetAllDonationsRequest(int? Page): IRequest<PagedResponse<GetAllDonationsResponse>>
    {
    }
}

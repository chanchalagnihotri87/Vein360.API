using MediatR;  
using System;
using System.Collections.Generic;
using System.Linq;      
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.DonationsFeatures.GetDonorDonations
{                                                                                                                           
    public sealed record GetDonorDonationsRequest(int? Page): IRequest<PagedResponse<GetDonorDonationsResponse>>
    {
    }
}

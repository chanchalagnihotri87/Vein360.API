using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.ProductRates.GetProductRates
{
    public record GetProductRateRequest(int UserId) : IRequest<List<ProductRateDto>>
    {
    }
}

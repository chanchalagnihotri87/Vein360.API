using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.ProductRates.SaveProductRates
{
    public record SaveProductRatesRequest(int UserId, List<ProductRateDto> ProductRates) : IRequest
    {
    }
}

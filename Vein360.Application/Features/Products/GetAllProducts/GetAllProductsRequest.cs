using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Common.Dtos;

namespace Vein360.Application.Features.Products.GetAllProducts
{
    public record GetAllProductsRequest : IRequest<List<ProductDto>>
    {
    }
}

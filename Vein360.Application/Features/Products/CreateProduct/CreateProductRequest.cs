using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.Products.CreateProduct
{
    public record CreateProductRequest(string Name, string Description, decimal Price, ProductType Type, IFormFile? ImageFile) : IRequest
    {
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.Products.UpdateProduct
{
    public record UpdateProductRequest(int Id, string Name, string Description, decimal Price, ProductType Type) : IRequest
    {
        public IFormFile? ImageFile { get; set; } = null;
    }
}

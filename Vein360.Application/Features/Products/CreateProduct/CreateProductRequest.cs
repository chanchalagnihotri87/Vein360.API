using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.Products.CreateProduct
{
    //public record CreateProductRequest(string Name, string Vein360ProductId, ProductType Type, TradeType Trade, IFormFile? ImageFile, decimal? Price = null) : IRequest
    //{
    //}

    public record CreateProductRequest : IRequest
    {
        public string Name { get; set; }
        public string Vein360ProductId { get; set; }
        public ProductType Type { get; set; }
        public TradeType Trade { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string Price { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Dtos;
using Vein360.Application.Repository.ProductRepository;

namespace Vein360.Application.Features.Products.GetAllProducts
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsRequest, List<ProductDto>>
    {
        private readonly IProductRepository _productRepo;

        public GetAllProductsHandler(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<List<ProductDto>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            var products = await _productRepo.GetAllAsync(cancellationToken);

            return products.Adapt<List<ProductDto>>();
        }
    }
}

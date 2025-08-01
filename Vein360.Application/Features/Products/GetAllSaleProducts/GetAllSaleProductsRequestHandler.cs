using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Features.Products.GetAllProducts;
using Vein360.Application.Repository.ProductRepository;

namespace Vein360.Application.Features.Products.GetAllSaleProducts
{
    public class GetAllSaleProductsRequestHandler : IRequestHandler<GetAllSaleProductsRequest, List<ProductDto>>
    {
        private readonly IProductRepository _productRepo;

        public GetAllSaleProductsRequestHandler(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<List<ProductDto>> Handle(GetAllSaleProductsRequest request, CancellationToken cancellationToken)
        {
            var products = await _productRepo.GetManyAsNoTrackingAsync(x => x.Trade == TradeType.Sale, cancellationToken);

            return products.Adapt<List<ProductDto>>();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository.ProductRepository;
using Vein360.Application.Repository.UserProductRateRepository;

namespace Vein360.Application.Features.UserProducts.GetProduct
{
    public record GetUserProductRequestHandler : IRequestHandler<GetUserProductRequest, UserProductDto>
    {
        private readonly IUserProductRateRepository _userProductRateRepo;
        private readonly IProductRepository _productRepo;


        public GetUserProductRequestHandler(
            IProductRepository productRepo,
            IUserProductRateRepository userProductRateRepo)
        {
            _productRepo = productRepo;
            _userProductRateRepo = userProductRateRepo;
        }

        public async Task<UserProductDto> Handle(GetUserProductRequest request, CancellationToken cancellationToken)
        {
            var userProduct = await _userProductRateRepo.GetAsync(x => x.ProductId == request.ProductId, cancellationToken, x => x.Include(y => y.Product));

            if (userProduct.IsNotNull())
            {
                var userProductResp = userProduct.Product.Adapt<UserProductDto>();

                if (userProductResp.IsNotNull() && userProduct.Price.IsNotNull())
                {
                    userProductResp.Price = Convert.ToDecimal(userProduct!.Price);
                }

                return userProductResp;
            }


            var product = await _productRepo.GetByIdAsync(request.ProductId);

            var productResp = product.Adapt<UserProductDto>();

            return productResp;
        }
    }
}

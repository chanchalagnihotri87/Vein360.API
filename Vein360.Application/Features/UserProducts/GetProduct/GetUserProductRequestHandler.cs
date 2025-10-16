using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository.ProductRepository;
using Vein360.Application.Repository.UserProductRateRepository;
using Vein360.Application.Service.AuthenticationService;

namespace Vein360.Application.Features.UserProducts.GetProduct
{
    public record GetUserProductRequestHandler : IRequestHandler<GetUserProductRequest, UserProductDto>
    {
        
        private readonly IProductRepository _productRepo;
        private readonly IAuthInfoService _authInfoService;
        private readonly IUserProductRateRepository _userProductRateRepo;

        public GetUserProductRequestHandler(
            IProductRepository productRepo,
            IAuthInfoService authInfoService,
            IUserProductRateRepository userProductRateRepo)
        {
            _productRepo = productRepo;
            _authInfoService = authInfoService;
            _userProductRateRepo = userProductRateRepo;
        }

        public async Task<UserProductDto> Handle(GetUserProductRequest request, CancellationToken cancellationToken)
        {
            var userProduct = await _userProductRateRepo.GetAsync(x => x.ProductId == request.ProductId && x.UserId == _authInfoService.UserId, cancellationToken, x => x.Include(y => y.Product));

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

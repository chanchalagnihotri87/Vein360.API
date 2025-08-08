using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository.ProductRepository;
using Vein360.Application.Repository.UserProductRateRepository;
using Vein360.Application.Service.AuthenticationService;

namespace Vein360.Application.Features.UserProducts.GetSortProducts
{
    public class GetUserSortProductsHandler : IRequestHandler<GetUserSortProductsRequest, List<UserProductDto>>
    {
        private readonly IProductRepository _productRepo;
        private readonly IUserProductRateRepository _productRateRepo;
        private readonly IAuthInfoService _authInfo;

        public GetUserSortProductsHandler(
            IProductRepository productRepo,
            IUserProductRateRepository productRateRepo,
            IAuthInfoService authInfo)
        {
            _productRepo = productRepo;
            _productRateRepo = productRateRepo;
            _authInfo = authInfo;
        }

        public async Task<List<UserProductDto>> Handle(GetUserSortProductsRequest request, CancellationToken cancellationToken)
        {
            var userProductRates = await _productRateRepo.GetManyAsNoTrackingAsync(x => x.UserId == _authInfo.UserId && x.Product.Trade == TradeType.Sort);

            if (userProductRates.HasItems())
            {
                var products = await _productRepo.GetSortProductsAsNoTrackingAsync(userProductRates.Select(x => x.ProductId).ToList());

                var userProducts = products.Adapt<List<UserProductDto>>();


                foreach (var userProduct in userProducts)
                {
                    var userProductRate = userProductRates.FirstOrDefault(x => x.ProductId == userProduct.Id);

                    if (userProductRate != null)
                    {
                        userProduct.IncludedInContract = true;

                        if (userProductRate.Price.IsNotNull())
                        {
                            userProduct.Price = Convert.ToDecimal(userProductRate.Price);
                        }

                    }
                }

                return userProducts;
            }

            return new List<UserProductDto>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository.ProductRepository;
using Vein360.Application.Repository.UserProductRateRepository;
using Vein360.Application.Service.AuthenticationService;

namespace Vein360.Application.Features.UserProducts.GetProducts
{
    public class GetUserProductsHandler : IRequestHandler<GetUserProductsRequest, List<UserProductDto>>
    {
        private readonly IProductRepository _productRepo;
        private readonly IUserProductRateRepository _productRateRepo;
        private readonly IAuthInfoService _authInfo;

        public GetUserProductsHandler(
            IProductRepository productRepo,
            IUserProductRateRepository productRateRepo,
            IAuthInfoService authInfo)
        {
            _productRepo = productRepo;
            _productRateRepo = productRateRepo;
            _authInfo = authInfo;
        }

        public async Task<List<UserProductDto>> Handle(GetUserProductsRequest request, CancellationToken cancellationToken)
        {
            var products = await _productRepo.GetAllAsNoTrackingAsync();

            var userProducts = products.Adapt<List<UserProductDto>>();

            var userProductRates = await _productRateRepo.GetManyAsNoTrackingAsync(x => x.UserId == _authInfo.UserId);


            foreach (var userProduct in userProducts)
            {
                var userProductRate = userProductRates.FirstOrDefault(x => x.ProductId == userProduct.Id);

                if (userProductRate != null)
                {
                    userProduct.IncludedInContract = true;
                }

                userProduct.BuyingPrice = userProductRate?.BuyingPrice ?? Convert.ToDouble(userProduct.Price);
                userProduct.SellingPrice = userProductRate?.SellingPrice ?? Convert.ToDouble(userProduct.Price);
            }

            var result= userProducts.OrderByDescending(x => x.IncludedInContract).ToList();

            return result;
        }
    }
}

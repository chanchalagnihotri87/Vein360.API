using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository.ProductRepository;
using Vein360.Application.Repository.UserProductRateRepository;

namespace Vein360.Application.Features.ProductRates.GetProductRates
{
    public class GetProductRateRequestHandler : IRequestHandler<GetProductRateRequest, List<ProductRateDto>>
    {
        private readonly IProductRepository _productRepo;
        private readonly IUserProductRateRepository _userProductRateRepo;


        public GetProductRateRequestHandler(IProductRepository productRepo, IUserProductRateRepository userProductRateRepo)
        {
            _productRepo = productRepo;
            _userProductRateRepo = userProductRateRepo;
        }

        public async Task<List<ProductRateDto>> Handle(GetProductRateRequest request, CancellationToken cancellationToken)
        {
            var productRates = await  _userProductRateRepo.GetManyAsync(x => x.UserId == request.UserId);

            return productRates.Adapt<List<ProductRateDto>>();
        }
    }
}

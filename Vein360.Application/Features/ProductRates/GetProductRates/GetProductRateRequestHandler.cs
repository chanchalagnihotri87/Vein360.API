using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository.UserProductRateRepository;

namespace Vein360.Application.Features.ProductRates.GetProductRates
{
    public class GetProductRateRequestHandler : IRequestHandler<GetProductRateRequest, List<ProductRateDto>>
    {
        private readonly IUserProductRateRepository _userProductRateRepo;

        public GetProductRateRequestHandler(IUserProductRateRepository userProductRateRepo)
        {
            _userProductRateRepo = userProductRateRepo;
        }

        public async Task<List<ProductRateDto>> Handle(GetProductRateRequest request, CancellationToken cancellationToken)
        {
            var productRates = await _userProductRateRepo.GetManyAsync(x => x.UserId == request.UserId);

            return productRates.Adapt<List<ProductRateDto>>();
        }
    }
}

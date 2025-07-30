using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository;
using Vein360.Application.Repository.UserProductRateRepository;
using Vein360.Domain.Entities;

namespace Vein360.Application.Features.ProductRates.SaveProductRates
{
    public class SaveProductRateRequestHandler : IRequestHandler<SaveProductRatesRequest>
    {
        private IUnitOfWork _unitOfWork;
        private readonly IUserProductRateRepository _userProductRateRepo;
        public SaveProductRateRequestHandler(
            IUnitOfWork unitOfWork,
            IUserProductRateRepository userProductRateRepo)
        {
            _unitOfWork = unitOfWork;
            _userProductRateRepo = userProductRateRepo;
        }

        public async Task Handle(SaveProductRatesRequest request, CancellationToken cancellationToken)
        {
            var dbUserProductRates = await _userProductRateRepo.GetManyAsync(x => x.UserId == request.UserId);

            if (dbUserProductRates.HasItems())
            {
                //Update Existing user product rates
                foreach (var dbUserProductRate in dbUserProductRates)
                {
                    var productRate = request.ProductRates.FirstOrDefault(x => x.ProductId == dbUserProductRate.ProductId);

                    if (productRate != null)
                    {
                        dbUserProductRate.SellingPrice = productRate.SellingPrice;
                        dbUserProductRate.PayToSalesCredit = productRate.PayToSalesCredit;
                        dbUserProductRate.BuyingPrice = productRate.BuyingPrice;
                        dbUserProductRate.PayFromSalesCredit = productRate.PayFromSalesCredit;

                        _userProductRateRepo.Update(dbUserProductRate);
                    }
                }



                //Add new product rates
                var newProductRates = request.ProductRates.Where(prodRate => !dbUserProductRates.Any(dbProdRate => dbProdRate.ProductId == prodRate.ProductId)).
                                                           Select(prodRate => MapToUserProduct(prodRate));
                _userProductRateRepo.CreateMany(newProductRates);


                //Delete Old products rates which are not application now.
                var deletedProductRates = dbUserProductRates.Where(dpr => !request.ProductRates.Any(rpr => rpr.ProductId == dpr.ProductId));
                _userProductRateRepo.DeleteMany(deletedProductRates);


                await _unitOfWork.SaveAsync(cancellationToken);

                return;
            }

            if (request.ProductRates.HasItems())
            {
                foreach (var newProductRate in request.ProductRates)
                {
                    UserProductRate userProductRate = MapToUserProduct(newProductRate);

                    _userProductRateRepo.Create(userProductRate);
                }

                await _unitOfWork.SaveAsync(cancellationToken);
            }

           
             UserProductRate MapToUserProduct(ProductRateDto productRate)
            {
                return new UserProductRate
                {
                    UserId = request.UserId,
                    ProductId = productRate.ProductId,
                    SellingPrice = productRate.SellingPrice,
                    PayToSalesCredit = productRate.PayToSalesCredit,
                    BuyingPrice = productRate.BuyingPrice,
                    PayFromSalesCredit = productRate.PayFromSalesCredit
                };
            }
        }
    }
}

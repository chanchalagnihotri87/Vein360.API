using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository;
using Vein360.Application.Repository.DonationsRepository;
using Vein360.Application.Repository.UserProductRateRepository;

namespace Vein360.Application.Features.Donations.SortDonation
{
    public class SortDonationRequestHandler : IRequestHandler<SortDonationRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDonationRepository _donationRepo;
        private readonly IUserProductRateRepository _userProductRateRepo;

        public SortDonationRequestHandler(IUnitOfWork unitOfWork, IDonationRepository donationRepo, IUserProductRateRepository userProductRateRepo)
        {
            _unitOfWork = unitOfWork;
            _donationRepo = donationRepo;
            _userProductRateRepo = userProductRateRepo;
        }

        public async Task Handle(SortDonationRequest request, CancellationToken cancellationToken)
        {
            var donation = await _donationRepo.GetAsync(x => x.ContainerId == request.ContainerId, cancellationToken,
                                         x => x.Include(x => x.Products));

            //Get Rates of all donation products
            var productRates = _userProductRateRepo.GetManyAsNoTracking(x => x.UserId == donation.DonorId, x => x).ToList();


            if (donation == null)
            {
                throw new Exception("Donation not found.");
            }

            foreach (var donationProduct in donation.Products)
            {
                var sortedDonationProduct = request.Products.FirstOrDefault(x => x.ProductId == donationProduct.ProductId);

                if (sortedDonationProduct != null)
                {
                    donationProduct.Accepted = sortedDonationProduct.AcceptedUnits;

                    donationProduct.RejectedClogged = sortedDonationProduct.RejectedClogged;
                    donationProduct.RejectedDamaged = sortedDonationProduct.RejectedDamaged;
                    donationProduct.RejectedFunction = sortedDonationProduct.RejectedFunction;
                    donationProduct.RejectedKinked = sortedDonationProduct.RejectedKinked;
                    donationProduct.RejectedOther = sortedDonationProduct.RejectedOther;

                    donation.Amount += CalculateAmount(sortedDonationProduct);
                }

                donation.Status = DonationStatus.Processed;

                _donationRepo.Update(donation);

                await _unitOfWork.SaveAsync(cancellationToken);
            }

            double CalculateAmount(SortedDonationProductDto sortedDonationProduct)
            {
                if (productRates != null && productRates.Count > 0)
                {
                    var productRate = productRates.FirstOrDefault(x => x.ProductId == sortedDonationProduct.ProductId);
                    if (productRate != null && productRate.Price != null)
                    {
                        return productRate.Price.Value * sortedDonationProduct.AcceptedUnits;
                    }
                }

                return 0;
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository;
using Vein360.Application.Repository.DonationsRepository;

namespace Vein360.Application.Features.Donations.SortDonation
{
    public class SortDonationRequestHandler : IRequestHandler<SortDonationRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDonationRepository _donationRepo;

        public SortDonationRequestHandler(IUnitOfWork unitOfWork, IDonationRepository donationRepo)
        {
            _unitOfWork = unitOfWork;
            _donationRepo = donationRepo;
        }

        public async Task Handle(SortDonationRequest request, CancellationToken cancellationToken)
        {
            var donation = await _donationRepo.GetAsync(x => x.ContainerId == request.ContainerId, cancellationToken,
                                         x => x.Include(x => x.Products));

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
                }
            }
            donation.Amount = request.TotalAmount;

            _donationRepo.Update(donation);

            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository;
using Vein360.Application.Repository.DonationsRepository;

namespace Vein360.Application.Features.Donations.DispatchDonation
{
    public class DispatchDonationHandler : IRequestHandler<DispatchDonationRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDonationRepository _donationRepo;

        public DispatchDonationHandler(IUnitOfWork unitOfWork,
                                       IDonationRepository dontationRepo)
        {
            _unitOfWork = unitOfWork;
            _donationRepo = dontationRepo;
        }

        public async Task Handle(DispatchDonationRequest request, CancellationToken cancellationToken)
        {
            var donation = await _donationRepo.GetByIdAsync(request.DontationContainerId, cancellationToken);
            donation.Status = Vien360.Domain.Enums.DonationStatus.Dispatched;
            
            _donationRepo.Update(donation);

            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Common.Exceptions;
using Vein360.Application.Repository;
using Vein360.Application.Repository.DonationsRepository;

namespace Vein360.Application.Features.Donations.UpdateContainerId
{
    public class UpdateContainerIdRequestHandler : IRequestHandler<UpdateContainerIdRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDonationRepository _donationRepo;

        public UpdateContainerIdRequestHandler(
            IUnitOfWork unitOfWork,
            IDonationRepository donationRepo)
        {
            _unitOfWork = unitOfWork;
            _donationRepo = donationRepo;
        }

        public async Task Handle(UpdateContainerIdRequest request, CancellationToken cancellationToken)
        {
            var donation = await _donationRepo.GetAsync(x => x.TrackingNumber == request.trackingNumber, cancellationToken);

            if (donation == null)
            {
                throw new Exception("Donation not found.");
            }


            donation.ContainerId = request.containerId;
            donation.Status = DonationStatus.Received;

            _donationRepo.Update(donation);

            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}

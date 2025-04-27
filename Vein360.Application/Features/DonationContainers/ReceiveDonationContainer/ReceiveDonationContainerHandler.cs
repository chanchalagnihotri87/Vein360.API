using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository;
using Vein360.Application.Repository.DonationContainerRepository;

namespace Vein360.Application.Features.DonationContainers.ReceiveDonationContainer
{
    public class ReceiveDonationContainerHandler : IRequestHandler<ReceiveDonationContainerRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDonationContainerRepository _donationContainerRepo;

        public ReceiveDonationContainerHandler(IUnitOfWork unitOfWork,
            IDonationContainerRepository donationContainerRepo)
        {
            _unitOfWork = unitOfWork;
            _donationContainerRepo = donationContainerRepo;
        }

        public async Task Handle(ReceiveDonationContainerRequest request, CancellationToken cancellationToken)
        {
            var donationContainer = await _donationContainerRepo.GetByIdAsync(request.donationContainerId, cancellationToken);
            donationContainer.Status = Vien360.Domain.Enums.DonationContainerStatus.Received;

            _donationContainerRepo.Update(donationContainer);

            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}

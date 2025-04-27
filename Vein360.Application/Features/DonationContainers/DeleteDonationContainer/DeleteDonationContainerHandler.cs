using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository;
using Vein360.Application.Repository.DonationContainerRepository;

namespace Vein360.Application.Features.DonationContainers.DeleteDonationContainer
{
    public class DeleteDonationContainerHandler : IRequestHandler<DeleteDonationContainerRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDonationContainerRepository _donationContainerRepo;

        public DeleteDonationContainerHandler(IUnitOfWork unitOfWork,
            IDonationContainerRepository donationContainerRepo)
        {
            _unitOfWork = unitOfWork;
            _donationContainerRepo = donationContainerRepo;
        }

        public async Task Handle(DeleteDonationContainerRequest request, CancellationToken cancellationToken)
        {
            var donationContainer = await _donationContainerRepo.GetByIdAsync(request.ContainerId);

            _donationContainerRepo.Delete(donationContainer);

            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}

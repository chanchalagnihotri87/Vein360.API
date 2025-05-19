using Vein360.Application.Repository;
using Vein360.Application.Repository.DonationContainerRepository;

namespace Vein360.Application.Features.DonationContainers.RejectDonationContainer
{
    public class RejectDonationContainerRequestHandler : IRequestHandler<RejectDonationContainerRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDonationContainerRepository _donationContainerRepo;

        public RejectDonationContainerRequestHandler(
            IUnitOfWork unitOfWork,
            IDonationContainerRepository donationContainerRepo)
        {
            _unitOfWork = unitOfWork;
            _donationContainerRepo = donationContainerRepo;
        }


        public async Task Handle(RejectDonationContainerRequest request, CancellationToken cancellationToken)
        {
            var donationContaier = await _donationContainerRepo.GetByIdAsync(request.Id, cancellationToken);

            donationContaier.Status = DonationContainerStatus.Rejected;

            _donationContainerRepo.Update(donationContaier);

            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}

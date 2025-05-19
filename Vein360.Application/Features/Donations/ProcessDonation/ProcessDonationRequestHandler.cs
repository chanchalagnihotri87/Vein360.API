using Microsoft.EntityFrameworkCore;
using Vein360.Application.Features.DonationsFeatures.GetAllDonations;
using Vein360.Application.Repository;
using Vein360.Application.Repository.DonationsRepository;


namespace Vein360.Application.Features.Donations.ProcessDonation
{
    public class ProcessDonationRequestHandler : IRequestHandler<ProcessDonationRequest, GetAllDonationsResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDonationRepository _donationRepo;

        public ProcessDonationRequestHandler(
            IUnitOfWork unitOfWork,
            IDonationRepository donationRepo)
        {
            _unitOfWork = unitOfWork;
            _donationRepo = donationRepo;
        }

        public async Task<GetAllDonationsResponse> Handle(ProcessDonationRequest request, CancellationToken cancellationToken)
        {
            var donation = await _donationRepo.GetAsync(x => x.Id == request.DonationId,
                                                        cancellationToken,
                                                        dnt => dnt.Include(x => x.Products).ThenInclude(x => x.Product),
                                                        dnt => dnt.Include(x => x.DonationContainer).ThenInclude(x => x.Container));
            if (donation != null)
            {
                foreach (var donationProduct in donation.Products)
                {
                    if (request.Products.Count(x => x.Id == donationProduct.Id) > 0)
                    {
                        var product = request.Products.FirstOrDefault(x => x.Id == donationProduct.Id);
                        if (product != null)
                        {
                            donationProduct.Accepted = product.Accepted;
                            donationProduct.Rejected = product.Rejected;
                        }
                    }
                }

                donation.Status = DonationStatus.Processed;
            }

            if (donation.ContainerType == ContainerType.Vein360Container && donation.DonationContainer != null)
            {
                donation.DonationContainer.MarkAsProcessed();
            }




            await _unitOfWork.SaveAsync(cancellationToken);

            return donation.Adapt<GetAllDonationsResponse>();
        }
    }
}

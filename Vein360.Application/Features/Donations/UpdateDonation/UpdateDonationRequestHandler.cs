using Microsoft.EntityFrameworkCore;
using Vein360.Application.Features.DonationsFeatures.GetAllDonations;
using Vein360.Application.Repository;
using Vein360.Application.Repository.DonationContainerRepository;
using Vein360.Application.Repository.DonationsRepository;
using Vein360.Application.Service.AuthenticationService;
using Vein360.Application.Service.ShipmentService;
using Vein360.Application.Service.StorageService;
using Vein360.Domain.Entities;

namespace Vein360.Application.Features.Donations.UpdateDonation
{
    public class UpdateDonationRequestHandler : IRequestHandler<UpdateDonationRequest, GetAllDonationsResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDonationRepository _donationRepository;


        public UpdateDonationRequestHandler(IUnitOfWork unitOfWork,
                                            IDonationRepository donationRepository)
        {
            _unitOfWork = unitOfWork;
            _donationRepository = donationRepository;
        }

        public async Task<GetAllDonationsResponse> Handle(UpdateDonationRequest request, CancellationToken cancellationToken)
        {
            Donation donation = await _donationRepository.GetAsync(x => x.Id == request.Id, cancellationToken, x => x.Include(x => x.Products).ThenInclude(x => x.Product));

            donation.Amount = request.Amount;

            _donationRepository.Update(donation);

            await _unitOfWork.SaveAsync(cancellationToken);

            return donation.Adapt<GetAllDonationsResponse>();
        }
    }
}

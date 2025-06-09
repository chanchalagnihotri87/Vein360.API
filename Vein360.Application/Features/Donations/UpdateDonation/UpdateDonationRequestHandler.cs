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
        private readonly IAuthInfoService _authInfo;
        private readonly IStorageService _storageService;
        private readonly IShipmentService _shipmentService;
        private readonly IDonationRepository _donationRepository;
        private readonly IDonationContainerRepository _donationContainerTypeRepo;

        public UpdateDonationRequestHandler(IUnitOfWork unitOfWork,
                                            IAuthInfoService authInfo,
                                            IStorageService storageService,
                                            IShipmentService shipmentService,
                                            IDonationRepository donationRepository,
                                            IDonationContainerRepository donationContainerTypeRepo)
        {
            _unitOfWork = unitOfWork;
            _authInfo = authInfo;
            _storageService = storageService;
            _shipmentService = shipmentService;
            _donationRepository = donationRepository;
            _donationContainerTypeRepo = donationContainerTypeRepo;
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

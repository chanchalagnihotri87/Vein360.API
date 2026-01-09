using Microsoft.EntityFrameworkCore;
using Vein360.Application.Common.Factories;
using Vein360.Application.Common.Helpers;
using Vein360.Application.Common.Helpers.Costants;
using Vein360.Application.Common.Helpers.WeightCalculator;
using Vein360.Application.Features.Donations.Shared;
using Vein360.Application.Repository;
using Vein360.Application.Repository.ClinicRepository;
using Vein360.Application.Repository.DonationContainerRepository;
using Vein360.Application.Repository.DonationsRepository;
using Vein360.Application.Repository.PickupRepository;
using Vein360.Application.Repository.ShippingLabelRepository;
using Vein360.Application.Repository.Vein360ContainerTypeRepository;
using Vein360.Application.Service.AuthenticationService;
using Vein360.Application.Service.ShipmentService;
using Vein360.Application.Service.StorageService;
using Vein360.Domain.Entities;

namespace Vein360.Application.Features.Donations.CreateDonation
{
    public class CreateDonationRequestHandler : IRequestHandler<CreateDonationRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthInfoService _authInfo;
        private readonly IClinicRepository _clinicalRepo;
        private readonly IDonationRepository _donationRepository;
        private readonly IDonationShippingDetailHandler _donationShippingDetailHandler;

        public CreateDonationRequestHandler(IUnitOfWork unitOfWork,
                                            IAuthInfoService authInfo,
                                            IPickupRepository pickupRepo,
                                            IClinicRepository clinicRepo,
                                            IDonationRepository donationRepository,
                                            IDonationShippingDetailHandler donationShippingDetailHandler
                                            )
        {
            _authInfo = authInfo;
            _unitOfWork = unitOfWork;
            _clinicalRepo = clinicRepo;
            _donationRepository = donationRepository;
            _donationShippingDetailHandler = donationShippingDetailHandler;
        }

        public async Task Handle(CreateDonationRequest request, CancellationToken cancellationToken)
        {
            Donation donation = DonationFactory.CreateDonation(request.ClinicId, request.TrackingNumber,
                                                               request.Products, _authInfo.UserId);

            _donationRepository.Create(donation);

            var clinic = await _clinicalRepo.GetByIdAsync(donation.ClinicId);

            await _donationShippingDetailHandler.HandleAsync(clinic, donation, cancellationToken);

            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}


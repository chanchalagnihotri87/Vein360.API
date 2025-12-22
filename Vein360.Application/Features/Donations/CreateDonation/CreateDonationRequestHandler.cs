using Microsoft.EntityFrameworkCore;
using Vein360.Application.Common.Factories;
using Vein360.Application.Common.Helpers;
using Vein360.Application.Common.Helpers.Costants;
using Vein360.Application.Common.Helpers.WeightCalculator;
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

        private readonly IPickupRepository _pickupRepo;
        private readonly IPickupService _pickupService;
        private readonly IClinicRepository _clinicalRepo;
        private readonly IStorageService _storageService;
        private readonly IShipmentService _shipmentService;
        private readonly IDonationRepository _donationRepository;
        private readonly IShippingLabelRepository _shippingLabelRepo;



        public CreateDonationRequestHandler(IUnitOfWork unitOfWork,
                                            IAuthInfoService authInfo,
                                            IPickupRepository pickupRepo,
                                            IClinicRepository clinicRepo,
                                            IStorageService storageService,
                                            IShipmentService shipmentService,
                                            IPickupService pickupService,
                                            IShippingLabelRepository shippingLabelRepo,
                                            IDonationRepository donationRepository
                                            )
        {
            _authInfo = authInfo;
            _unitOfWork = unitOfWork;
            _pickupRepo = pickupRepo;
            _clinicalRepo = clinicRepo;
            _storageService = storageService;
            _shipmentService = shipmentService;
            _pickupService = pickupService;
            _shippingLabelRepo = shippingLabelRepo;
            _donationRepository = donationRepository;
        }

        public async Task Handle(CreateDonationRequest request, CancellationToken cancellationToken)
        {
            Donation donation = DonationFactory.CreateDonation(request.ClinicId,
                                                                   request.TrackingNumber,
                                                                   request.Products,
                                                                   _authInfo.UserId);

            var clinic = await _clinicalRepo.GetByIdAsync(donation.ClinicId);

            try
            {
                _donationRepository.Create(donation);

                await UpdateShipmentLabelInfoAsync(donation);

                await UpdateShipmentPickupInfoAsync();

                await _unitOfWork.SaveAsync(cancellationToken);
            }
            catch (Exception)
            {
                await RollbackFedexShipmentAndPickup();

                throw;
            }

            async Task UpdateShipmentLabelInfoAsync(Donation donation)
            {
                if (donation.UseOldLabel)
                {
                    await MarkShippingLabelAsUsed(donation.TrackingNumber!.Value, cancellationToken);
                }
                else
                {
                    var shipmentInfo = await _shipmentService.CreateDonationShipmentAsync(CalculateWeight(request.Products), clinic);

                    var shipmentLabelFileName = await StoreShipmentLabelAsync(shipmentInfo);

                    donation.LabelFileName = shipmentLabelFileName;
                    donation.FedexTransactionId = shipmentInfo.TransactionId;
                    donation.MasterTrackingNumber = shipmentInfo.MasterTrackingNumber.ToLong();
                    donation.TrackingNumber = shipmentInfo.TrackingNumber.ToLong();
                }

                async Task MarkShippingLabelAsUsed(long trackingNumber, CancellationToken cancellationToken)
                {
                    var shippingLabel = await _shippingLabelRepo.GetLabelByTrackingNumber(trackingNumber, cancellationToken);

                    shippingLabel.Used = true;

                    _shippingLabelRepo.Update(shippingLabel);
                }

                async Task<string> StoreShipmentLabelAsync(ShipmentDetailDto shipmentInfo)
                {
                    string shipmentLabelFileName = null;

                    if (shipmentInfo.EncodedLabel.IsNotNullOrEmpty())
                    {
                        shipmentLabelFileName = await _storageService.StoreEncodedLabelAsync(shipmentInfo.TrackingNumber.ToLong(),
                                                                                 shipmentInfo.EncodedLabel);
                    }
                    else if (shipmentInfo.LabelUrl.IsNotNullOrEmpty())
                    {
                        shipmentLabelFileName = await _storageService.StoreUrlLabelAsync(shipmentInfo.TrackingNumber.ToLong(), shipmentInfo.LabelUrl);
                    }

                    return shipmentLabelFileName;
                }
            }

            double CalculateWeight(List<DonationProductItemDto> products)
            {
                return new WeightCalculator().CalculateWeight(products.Sum(x => x.Units));
            }

            async Task UpdateShipmentPickupInfoAsync()
            {
                var pickupDateTime = _pickupService.GetPickupDateTime();

                // if there is already a pickup for the clinic on the same date, use that pickup info
                var previousSameDayPickup = await _pickupRepo.GetAsync(x => x.ClinicId == donation.ClinicId && x.PickupDateTime >= pickupDateTime.Date && x.PickupDateTime < pickupDateTime.AddDays(1).Date);
                if (previousSameDayPickup.IsNotNull())
                {
                    donation.PickupId = previousSameDayPickup.Id;
                    return;
                }

                // otherwise, create a new pickup and assign its info to the donation
                var pickupInfo = await _pickupService.CreatePickupAsync(clinic);
                var newPickup = PickupFactory.CreatePickup(donation.ClinicId, pickupInfo.TransactionId, pickupInfo.ConfirmationCode, pickupDateTime); ;
                _pickupRepo.Create(newPickup);

                donation.Pickup = newPickup;
            }

            async Task RollbackFedexShipmentAndPickup()
            {
                // Cancel Pickup only if it's newly created
                if (donation.Pickup.IsNotNull())
                {
                    await _pickupService.CancelPickupSafelyAsync(donation.Pickup.PickupConfirmationCode, donation.Pickup.PickupDateTime);
                }

                // Cancel Shipment if created
                if (donation.TrackingNumber.IsNotNull())
                {
                    await _shipmentService.CancelShipmentSafelyAsync(donation.TrackingNumber!.Value);
                }
            }
        }
    }
}

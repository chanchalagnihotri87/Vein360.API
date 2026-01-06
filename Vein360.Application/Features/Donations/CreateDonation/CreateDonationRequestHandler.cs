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
        private readonly IAddressValidationService _addressValidationService;



        public CreateDonationRequestHandler(IUnitOfWork unitOfWork,
                                            IAuthInfoService authInfo,
                                            IPickupRepository pickupRepo,
                                            IClinicRepository clinicRepo,
                                            IStorageService storageService,
                                            IShipmentService shipmentService,
                                            IPickupService pickupService,
                                            IShippingLabelRepository shippingLabelRepo,
                                            IDonationRepository donationRepository,
                                            IAddressValidationService addressValidationService
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
            _addressValidationService = addressValidationService;
        }

        public async Task Handle(CreateDonationRequest request, CancellationToken cancellationToken)
        {
            Donation donation = DonationFactory.CreateDonation(request.ClinicId, request.TrackingNumber,
                                                               request.Products, _authInfo.UserId);
            try
            {
                _donationRepository.Create(donation);

                var clinic = await _clinicalRepo.GetByIdAsync(donation.ClinicId);

                var formattedClinicAddress = await _addressValidationService.ValidateAddressAsync(clinic);

                // Create Shipment Pickup and Pickup Info in Donation
                var pickupTime = await UpdateShipmentPickupInfoAsync(donation, clinic, formattedClinicAddress);

                // Create Shipment Label and Shipment Info in Donation
                await UpdateShipmentLabelInfoAsync(donation, pickupTime, clinic, formattedClinicAddress);

                await _unitOfWork.SaveAsync(cancellationToken);
            }
            catch (Exception)
            {
                await RollbackFedexShipmentAndPickup();

                throw;
            }

            async Task<IPickupTime> UpdateShipmentPickupInfoAsync(Donation donation, Clinic clinic, AddressDto formattedClinicAddress)
            {
                //Get available pickup times from Fedex
                var availablePickupTimes = await _pickupService.CheckPickupAvailability(clinic.PostalCode, clinic.Country);

                if (availablePickupTimes.IsEmpty() || availablePickupTimes.All(x => x.ReadyDateTime.IsNull()))
                {
                    throw new Exception("Pickup is not available.");
                }


                // first, check if there's an existing pickup for the same clinic on the any available day
                foreach (var availablePickupTime in availablePickupTimes)
                {
                    var pickupDateTime = availablePickupTime!.ReadyDateTime;

                    var previousSameDayPickup = await _pickupRepo.GetAsync(x => x.ClinicId == donation.ClinicId && x.PickupDateTime >= pickupDateTime.Date && x.PickupDateTime < pickupDateTime.AddDays(1).Date);
                    if (previousSameDayPickup.IsNotNull())
                    {
                        donation.PickupId = previousSameDayPickup.Id;
                        return availablePickupTime;
                    }
                }


                // otherwise, create a new pickup and assign its info to the donation
                var pickupInfo = await _pickupService.CreatePickupAsync(clinic, availablePickupTimes, formattedClinicAddress);
                var newPickup = PickupFactory.CreatePickup(donation.ClinicId, pickupInfo.TransactionId, pickupInfo.ConfirmationCode, pickupInfo.PickupTime.ReadyDateTime); ;
                _pickupRepo.Create(newPickup);

                donation.Pickup = newPickup;

                return pickupInfo.PickupTime;
            }

            async Task UpdateShipmentLabelInfoAsync(Donation donation, IPickupTime pickupTime, Clinic clinic, AddressDto formattedClinicAddress)
            {
                // If using old label, just mark it as used and return
                if (donation.UseOldLabel)
                {
                    await MarkOldShippingLabelAsUsed(donation.TrackingNumber!.Value, cancellationToken);
                    return;
                }


                // otherwise, create a new shipment
                var shipmentInfo = await _shipmentService.CreateDonationShipmentAsync(CalculateWeight(request.Products), clinic, formattedClinicAddress, pickupTime.ReadyDateString);

                // Store shipment label
                var shipmentLabelFileName = await StoreShipmentLabelAsync(shipmentInfo);

                // Update donation with shipment info
                donation.LabelFileName = shipmentLabelFileName;
                donation.FedexTransactionId = shipmentInfo.TransactionId;
                donation.MasterTrackingNumber = shipmentInfo.MasterTrackingNumber.ToLong();
                donation.TrackingNumber = shipmentInfo.TrackingNumber.ToLong();



                // Local functions
                async Task MarkOldShippingLabelAsUsed(long trackingNumber, CancellationToken cancellationToken)
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
                double CalculateWeight(List<DonationProductItemDto> products)
                {
                    return new WeightCalculator().CalculateWeight(products.Sum(x => x.Units));
                }
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

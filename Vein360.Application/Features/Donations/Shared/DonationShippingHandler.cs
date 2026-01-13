using Microsoft.Extensions.Logging;
using Vein360.Application.Common.Exceptions;
using Vein360.Application.Common.Factories;
using Vein360.Application.Common.Helpers.WeightCalculator;
using Vein360.Application.Repository.PickupRepository;
using Vein360.Application.Repository.ShippingLabelRepository;
using Vein360.Application.Service.ShipmentService;
using Vein360.Application.Service.StorageService;
using Vein360.Domain.Entities;

namespace Vein360.Application.Features.Donations.Shared
{
    public class DonationShippingDetailHandler : IDonationShippingDetailHandler
    {
        private readonly IPickupRepository _pickupRepo;
        private readonly IPickupService _pickupService;
        private readonly IStorageService _storageService;
        private readonly IShipmentService _shipmentService;
        private readonly IShippingLabelRepository _shippingLabelRepo;
        private readonly IAddressValidationService _addressValidationService;
        private readonly ILogger<IDonationShippingDetailHandler> _logger;

        private ShipmentPickupDetailDto newPickup;
        private ShipmentDetailDto newShipment;



        public DonationShippingDetailHandler(IPickupRepository pickupRepo,
            IPickupService pickupService,
            IStorageService storageService,
            IShipmentService shipmentService,
            IShippingLabelRepository shippingLabelRepo,
            IAddressValidationService addressValidationService,
            ILogger<IDonationShippingDetailHandler> logger)
        {
            _logger = logger;
            _pickupRepo = pickupRepo;
            _pickupService = pickupService;
            _storageService = storageService;
            _shipmentService = shipmentService;
            _shippingLabelRepo = shippingLabelRepo;
            _addressValidationService = addressValidationService;
        }


        public async Task HandleAsync(Clinic clinic, Donation donation, CancellationToken cancellationToken)
        {
            try
            {
                var formattedClinicAddress = await _addressValidationService.ValidateAddressAsync(clinic);

                // Create Shipment Pickup and Store Pickup Info in Donation
                var pickupTime = await UpdateShipmentPickupInfoAsync(donation, clinic, formattedClinicAddress, cancellationToken);

                // Create Shipment Label and Store Shipment Info in Donation
                await UpdateShipmentLabelInfoAsync(donation, pickupTime, clinic, formattedClinicAddress, cancellationToken);

            }
            catch (Exception)
            {
                await RollbackFedexShipmentAndPickupAsync();

                throw; // to pass error upstream
            }
        }

        private async Task<IPickupTime> UpdateShipmentPickupInfoAsync(Donation donation, Clinic clinic, AddressDto formattedClinicAddress, CancellationToken cancellationToken)
        {
            //Check if there is already a pickup scheduled for future date for this donation's clinic
            var existingPickup = await _pickupRepo.GetAsync(x => x.ClinicId == donation.ClinicId && x.PickupDateTime > DateTime.Now);

            if (existingPickup != null)
            {
                donation.PickupId = existingPickup.Id;

                return AvailableTimeDto.FromPickup(existingPickup);
            }


            //Get available pickup times from Fedex
            var availablePickupTimes = await _pickupService.CheckPickupAvailability(clinic.PostalCode, clinic.Country);

            if (availablePickupTimes.IsEmpty())
            {
                throw new PickupNotAvaliable();
            }


            // first, check if there's an existing pickup for the same clinic on the any available day
            var upcomingPickups = await _pickupRepo.GetManyAsNoTrackingAsync(x => x.ClinicId == donation.ClinicId && x.PickupDateTime >= DateTime.Today.Date);

            if (upcomingPickups.HasItems())
            {
                foreach (var availablePickupTime in availablePickupTimes)
                {
                    var pickupDateTime = availablePickupTime!.ReadyDateTime;

                    var previousSameDayPickup = upcomingPickups.FirstOrDefault(x => x.PickupDateTime >= pickupDateTime.Date && x.PickupDateTime < pickupDateTime.AddDays(1).Date);

                    if (previousSameDayPickup.IsNotNull())
                    {
                        donation.PickupId = previousSameDayPickup.Id;
                        return availablePickupTime;
                    }
                }
            }


            //create a new pickup and assign its info to the donation
            this.newPickup = await _pickupService.CreatePickupAsync(clinic, availablePickupTimes, formattedClinicAddress);

            _logger.LogInformation($"Created new pickup for Clinic Id: {clinic.Id} with Confirmation Code: {this.newPickup.ConfirmationCode}");

            var newDBPickup = PickupFactory.CreatePickup(donation.ClinicId, this.newPickup.TransactionId, this.newPickup.ConfirmationCode, this.newPickup.PickupTime.ReadyDateTime); ;
            _pickupRepo.Create(newDBPickup);

            donation.Pickup = newDBPickup;

            return this.newPickup.PickupTime;
        }

        private async Task UpdateShipmentLabelInfoAsync(Donation donation, IPickupTime pickupTime, Clinic clinic, AddressDto formattedClinicAddress, CancellationToken cancellationToken)
        {
            // If using old label, just mark it as used and return
            if (donation.UseOldLabel)
            {
                await MarkOldShippingLabelAsUsed(donation.TrackingNumber!.Value, cancellationToken);
                return;
            }


            // otherwise, create a new shipment
            this.newShipment = await _shipmentService.CreateDonationShipmentAsync(CalculateWeight(donation.Products), clinic, formattedClinicAddress, pickupTime.ReadyDateString);

            _logger.LogInformation($"Created Shipment for Clinic Id: {clinic.Id} with Tracking Number: {this.newShipment.TrackingNumber}");

            // Store shipment label
            var shipmentLabelFileName = await StoreShipmentLabelAsync(this.newShipment);

            // Update donation with shipment info
            donation.LabelFileName = shipmentLabelFileName;
            donation.FedexTransactionId = this.newShipment.TransactionId;
            donation.MasterTrackingNumber = this.newShipment.MasterTrackingNumber.ToLong();
            donation.TrackingNumber = this.newShipment.TrackingNumber.ToLong();



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
            double CalculateWeight(ICollection<DonationProduct> products)
            {
                return new WeightCalculator().CalculateWeight(products.Sum(x => x.Units));
            }
        }

        private async Task RollbackFedexShipmentAndPickupAsync()
        {
            // Cancel Pickup only if it's newly created
            if (this.newPickup.IsNotNull())
            {
                await _pickupService.CancelPickupSafelyAsync(this.newPickup.ConfirmationCode, this.newPickup.PickupTime.ReadyDateTime);
            }

            // Cancel Shipment if created
            if (this.newShipment.IsNotNull())
            {
                await _shipmentService.CancelShipmentSafelyAsync(this.newShipment.TrackingNumber.ToLong());
            }
        }
    }


    public interface IDonationShippingDetailHandler
    {
        Task HandleAsync(Clinic clinic, Donation donation, CancellationToken cancellationToken);
    }
}

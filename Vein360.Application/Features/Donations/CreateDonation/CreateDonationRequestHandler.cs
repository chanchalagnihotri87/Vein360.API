using Microsoft.EntityFrameworkCore;
using Vein360.Application.Common.Factories;
using Vein360.Application.Common.Helpers;
using Vein360.Application.Common.Helpers.Costants;
using Vein360.Application.Common.Helpers.WeightCalculator;
using Vein360.Application.Repository;
using Vein360.Application.Repository.ClinicRepository;
using Vein360.Application.Repository.DonationContainerRepository;
using Vein360.Application.Repository.DonationsRepository;
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
        private readonly IStorageService _storageService;
        private readonly IShipmentService _shipmentService;
        private readonly IPickupService _pickupService;
        private readonly IDonationRepository _donationRepository;
        private readonly IShippingLabelRepository _shippingLabelRepo;
        private readonly IVein360ContainerTypeRepository _containerTypeRepo;

        public CreateDonationRequestHandler(IUnitOfWork unitOfWork,
                                            IAuthInfoService authInfo,
                                            IClinicRepository clinicRepo,
                                            IStorageService storageService,
                                            IShipmentService shipmentService,
                                            IPickupService pickupService,
                                            IShippingLabelRepository shippingLabelRepo,
                                            IDonationRepository donationRepository,
                                            IVein360ContainerTypeRepository containerTypeRepo)
        {
            _authInfo = authInfo;
            _unitOfWork = unitOfWork;
            _clinicalRepo = clinicRepo;
            _storageService = storageService;
            _shipmentService = shipmentService;
            _pickupService = pickupService;
            _shippingLabelRepo = shippingLabelRepo;
            _containerTypeRepo = containerTypeRepo;
            _donationRepository = donationRepository;
        }

        public async Task Handle(CreateDonationRequest request, CancellationToken cancellationToken)
        {
            Donation donation = DonationFactory.CreateDonation(request.ClinicId,
                                                               request.TrackingNumber,
                                                               request.Products,
                                                               _authInfo.UserId);

            _donationRepository.Create(donation);

            var clinic = await _clinicalRepo.GetByIdAsync(donation.ClinicId);

            await UpdateShipmentLabelInfoAsync(donation);

            await UpdateShipmentPickupInfoAsync();

            await _unitOfWork.SaveAsync(cancellationToken);


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
                //Commented due to already pickup check need to add because duplicate pickup with same date throwing error.

                //var pickupInfo = await _pickupService.CreatePickupAsync(clinic);

                //donation.PickupTransactionId = pickupInfo.TransactionId;
                //donation.PickupConfirmationCode = pickupInfo.ConfirmationCode;

                donation.PickupTransactionId = "e45934f4-be66-45b7-840f-4de2143464aa";
                donation.PickupConfirmationCode = "CPU3864053521";
            }
        }
    }
}

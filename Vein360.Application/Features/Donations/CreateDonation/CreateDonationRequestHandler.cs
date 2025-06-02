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
        private readonly IDonationRepository _donationRepository;
        private readonly IShippingLabelRepository _shippingLabelRepo;
        private readonly IVein360ContainerTypeRepository _containerTypeRepo;

        public CreateDonationRequestHandler(IUnitOfWork unitOfWork,
                                            IAuthInfoService authInfo,
                                            IClinicRepository clinicRepo,
                                            IStorageService storageService,
                                            IShipmentService shipmentService,
                                            IShippingLabelRepository shippingLabelRepo,
                                            IDonationRepository donationRepository,
                                            IVein360ContainerTypeRepository containerTypeRepo)
        {
            _authInfo = authInfo;
            _unitOfWork = unitOfWork;
            _clinicalRepo = clinicRepo;
            _storageService = storageService;
            _shipmentService = shipmentService;
            _shippingLabelRepo = shippingLabelRepo;
            _containerTypeRepo = containerTypeRepo;
            _donationRepository = donationRepository;
        }

        public async Task Handle(CreateDonationRequest request, CancellationToken cancellationToken)
        {
            Donation donation = DonationFactory.CreateDonation(request.ClinicId,
                                                               request.PackageType,
                                                               request.ContainerTypeId,
                                                               request.FedexPackagingTypeId,
                                                               request.TrackingNumber,
                                                               request.Products,
                                                               _authInfo.UserId);

            _donationRepository.Create(donation);

            await UpdateShipmentInfo(donation);

            await _unitOfWork.SaveAsync(cancellationToken);


            async Task UpdateShipmentInfo(Donation donation)
            {
                if (donation.UseOldLabel)
                {
                    await MarkShippingLabelAsUsed(donation.TrackingNumber!.Value, cancellationToken);
                }
                else
                {
                    var clinic = await _clinicalRepo.GetByIdAsync(donation.ClinicId);

                    var shipmentInfo = await _shipmentService.CreateDonationShipmentAsync(request.PackageType,
                                                                            request.FedexPackagingTypeId,
                                                                            await CalculateWeight(request, cancellationToken),
                                                                            clinic);
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
            }

            async Task<double> CalculateWeight(CreateDonationRequest request, CancellationToken cancellationToken)
            {

                if (request.PackageType == PackageType.Vein360Container)
                {
                    var containerType = await _containerTypeRepo.GetByIdAsync(request.ContainerTypeId!.Value, cancellationToken);

                    return new WeightCalculator(containerType.EstimatedWeight).CalculateWeight(request.Products.Sum(x => x.Units));
                }

                if (request.PackageType == PackageType.CustomPacking)
                {
                    return new WeightCalculator(ConstantsHelper.OwnPackingContainerWeight).CalculateWeight(request.Products.Sum(x => x.Units));
                }

                return 0;
            }

        }
    }
}

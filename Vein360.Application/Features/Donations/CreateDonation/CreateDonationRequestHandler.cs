using Microsoft.EntityFrameworkCore;
using Vein360.Application.Common.Factories;
using Vein360.Application.Repository;
using Vein360.Application.Repository.DonationContainerRepository;
using Vein360.Application.Repository.DonationsRepository;
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
        private readonly IStorageService _storageService;
        private readonly IShipmentService _shipmentService;
        private readonly IDonationRepository _donationRepository;
        private readonly IDonationContainerRepository _donationContainerTypeRepo;

        public CreateDonationRequestHandler(IUnitOfWork unitOfWork,
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

        public async Task Handle(CreateDonationRequest request, CancellationToken cancellationToken)
        {
            Donation donation = DonationFactory.CreateDonation(request.ContainerType,
                                                               request.ContainerId,
                                                               request.length,
                                                               request.width,
                                                               request.height,
                                                               request.Products, _authInfo.UserId);

            if(donation.IsVein360ContainerDonation())
            {
                await MarkContainerAsFilled(request.ContainerId!.Value);
            }

            _donationRepository.Create(donation);

            await UpdateShipmentInfo(donation);

            await _unitOfWork.SaveAsync(cancellationToken);


            async Task UpdateShipmentInfo(Donation donation)
            {
                var shipmentInfo = await _shipmentService.CreateDonationShipmentAsync(request.ContainerType,
                                                                        request.ContainerId,
                                                                        await CalculateWeight(request, cancellationToken));

                var shipmentLabelFileName = await _storageService.StoreLabelAsync(shipmentInfo.TrackingNumber.ToLong(),
                                                                          shipmentInfo.EncodedLabel);

                donation.LabelFileName = shipmentLabelFileName;
                donation.FedexTransactionId = shipmentInfo.TransactionId;
                donation.MasterTrackingNumber = shipmentInfo.MasterTrackingNumber.ToLong();
                donation.TrackingNumber = shipmentInfo.TrackingNumber.ToLong();


            }

            async Task<double> CalculateWeight(CreateDonationRequest request, CancellationToken cancellationToken)
            {
                if (request.ContainerType == ContainerType.Vein360Container)
                {
                    var donationContainer = await _donationContainerTypeRepo.GetAsync(x => x.Id == request.ContainerId, cancellationToken, x => x.Include(cnt => cnt.ContainerType));

                    return donationContainer.ContainerType.EstimatedWeight;
                }

                if (request.ContainerType == ContainerType.OwnCustomPacking)
                {

                    var calculatedWeight = (request.length * request.width * request.height) / 139;
                    return Math.Round(calculatedWeight.Value, 2);
                }

                return 0;
            }

            async Task MarkContainerAsFilled(int containerId)
            {
                var donationContainer = await _donationContainerTypeRepo.GetAsync(x => x.Id == containerId, cancellationToken, x => x.Include(cnt => cnt.ContainerType));

                donationContainer.MarkAsFilled();

                _donationContainerTypeRepo.Update(donationContainer);
            }
        }
    }
}

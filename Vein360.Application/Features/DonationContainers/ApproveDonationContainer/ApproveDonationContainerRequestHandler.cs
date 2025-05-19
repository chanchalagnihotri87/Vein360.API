using Microsoft.EntityFrameworkCore;
using Vein360.Application.Common.Exceptions;
using Vein360.Application.Repository;
using Vein360.Application.Repository.ContainerRepository;
using Vein360.Application.Repository.DonationContainerRepository;
using Vein360.Application.Service.ShipmentService;
using Vein360.Application.Service.StorageService;
using Vein360.Domain.Entities;

namespace Vein360.Application.Features.DonationContainers.ApproveDonationContainer
{
    public class ApproveDonationContainerRequestHandler : IRequestHandler<ApproveDonationContainerRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStorageService _storageService;
        private readonly IShipmentService _shipmentService;
        private readonly IDonationContainerRepository _donationContainerRepo;
        private readonly IContainerRepository _containerRepo;


        public ApproveDonationContainerRequestHandler(
            IUnitOfWork unitOfWork,
            IStorageService storageService,
            IShipmentService shipmentService,
            IDonationContainerRepository donationContainerRepo,
            IContainerRepository containerRepo)

        {
            _unitOfWork = unitOfWork;
            _storageService = storageService;
            _shipmentService = shipmentService;
            _donationContainerRepo = donationContainerRepo;
            _containerRepo = containerRepo;
        }
        public async Task Handle(ApproveDonationContainerRequest request, CancellationToken cancellationToken)
        {
            var donationContainer = await _donationContainerRepo.GetAsync(x=> x.Id==request.DonationContainerId, 
                                                                              cancellationToken, 
                                                                              x=> x.Include(x=> x.Container));

            var container = await _containerRepo.GetAsync(x => x.Id == request.Vein360ContainerId, cancellationToken, x => x.Include(x => x.ContainerType));

            if (donationContainer == null)
            {
                throw new NotFoundException(nameof(DonationConatinerDto), request.DonationContainerId);
            }

            donationContainer.ContainerId = request.Vein360ContainerId;
            donationContainer.Container = container;

            donationContainer.MarkAsApproved();
            
            await UpdateShipmentInfo(donationContainer);


            _donationContainerRepo.Update(donationContainer);
            _containerRepo.Update(container);

            await _unitOfWork.SaveAsync(cancellationToken);


            async Task UpdateShipmentInfo(DonationContainer donationContainer)
            {
                var shipmentInfo = await _shipmentService.CreateDonationContainerShipmentAsync(container.ContainerType.EstimatedWeight);

                var shipmentLabelFileName = await _storageService.StoreLabelAsync(shipmentInfo.TrackingNumber.ToLong(),
                                                                          shipmentInfo.EncodedLabel);

                donationContainer.LabelFileName = shipmentLabelFileName;
                donationContainer.FedexTransactionId = shipmentInfo.TransactionId;
                donationContainer.MasterTrackingNumber = shipmentInfo.MasterTrackingNumber.ToLong();
                donationContainer.TrackingNumber = shipmentInfo.TrackingNumber.ToLong();
            }

        }
    }

}

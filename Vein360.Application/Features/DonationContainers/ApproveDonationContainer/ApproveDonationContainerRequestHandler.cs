using Microsoft.EntityFrameworkCore;
using Vein360.Application.Common.Exceptions;
using Vein360.Application.Repository;
using Vein360.Application.Repository.ContainerRepository;
using Vein360.Application.Repository.DonationContainerRepository;
using Vein360.Application.Service.ReplenishmentService;
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
        private readonly IReplenishmentService _replenishmentService;


        public ApproveDonationContainerRequestHandler(
            IUnitOfWork unitOfWork,
            IStorageService storageService,
            IShipmentService shipmentService,
            IDonationContainerRepository donationContainerRepo,
            IContainerRepository containerRepo,
            IReplenishmentService replenishmentService)

        {
            _unitOfWork = unitOfWork;
            _storageService = storageService;
            _shipmentService = shipmentService;
            _donationContainerRepo = donationContainerRepo;
            _containerRepo = containerRepo;
            _replenishmentService = replenishmentService;
        }
        public async Task Handle(ApproveDonationContainerRequest request, CancellationToken cancellationToken)
        {
            var donationContainer = await _donationContainerRepo.GetAsync(x => x.Id == request.DonationContainerId,
                                                                              cancellationToken);


            donationContainer.ApprovedUnits = request.ApprovedUnits;

         
            //Make a call to Vein360 internal system to create replenishment order
            donationContainer.ReplenishmentOrderId = _replenishmentService.CreateReplenishmentOrder(donationContainer.ContainerTypeId, request.ApprovedUnits, donationContainer.DonorId);

            donationContainer.MarkAsApproved();

            _donationContainerRepo.Update(donationContainer);

         



            await _unitOfWork.SaveAsync(cancellationToken);


        }
    }

}

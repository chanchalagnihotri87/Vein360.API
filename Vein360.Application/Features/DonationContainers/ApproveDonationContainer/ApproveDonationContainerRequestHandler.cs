using Microsoft.EntityFrameworkCore;
using Vein360.Application.Common.Exceptions;
using Vein360.Application.Repository;
using Vein360.Application.Repository.ContainerRepository;
using Vein360.Application.Repository.DonationContainerRepository;
using Vein360.Application.Service.AuthenticationService;
using Vein360.Application.Service.ReplenishmentService;
using Vein360.Application.Service.ShipmentService;
using Vein360.Application.Service.StorageService;
using Vein360.Domain.Entities;

namespace Vein360.Application.Features.DonationContainers.ApproveDonationContainer
{
    public class ApproveDonationContainerRequestHandler : IRequestHandler<ApproveDonationContainerRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthInfoService _authInfo;
        private readonly IDonationContainerRepository _donationContainerRepo;
        private readonly IReplenishmentService _replenishmentService;



        public ApproveDonationContainerRequestHandler(
            IUnitOfWork unitOfWork,
            IAuthInfoService authInfo,
            IStorageService storageService,
            IShipmentService shipmentService,
            IContainerRepository containerRepo,
            IDonationContainerRepository donationContainerRepo,
            IReplenishmentService replenishmentService
            )

        {
            _unitOfWork = unitOfWork;
            _authInfo = authInfo;
            _donationContainerRepo = donationContainerRepo;
            _replenishmentService = replenishmentService;
        }
        public async Task Handle(ApproveDonationContainerRequest request, CancellationToken cancellationToken)
        {
            var donationContainer = await _donationContainerRepo.GetAsync(x => x.Id == request.DonationContainerId,
                                                                              cancellationToken,
                                                                              y => y.Include(dc => dc.Clinic));

            donationContainer.ApprovedUnits = request.ApprovedUnits;

            //Make a call to Vein360 internal system to create replenishment order
            donationContainer.ReplenishmentOrderId = _replenishmentService.CreateReplenishmentOrder(donationContainer.ContainerTypeId, request.ApprovedUnits, donationContainer.Clinic.Vein360ClinicId, donationContainer.Id, _authInfo.UserName);

            donationContainer.MarkAsApproved();

            _donationContainerRepo.Update(donationContainer);

            await _unitOfWork.SaveAsync(cancellationToken);


        }
    }

}

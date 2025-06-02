using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository;
using Vein360.Application.Repository.DonationContainerRepository;
using Vein360.Application.Repository.ShippingLabelRepository;
using Vein360.Domain.Entities;

namespace Vein360.Application.Features.DonationContainers.ShipDonationContainer
{
    public class ShipDonationContainerRequestHandler : IRequestHandler<ShipDonationContainerRequest>
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly IShippingLabelRepository _shippingLabelRepo;
        private readonly IDonationContainerRepository _donationContainerRepo;


        public ShipDonationContainerRequestHandler(
            IUnitOfWork unitOfWork,
            IShippingLabelRepository shippingLabelRepo,
            IDonationContainerRepository donationContainerRepo
            )
        {
            _unitOfwork = unitOfWork;
            _shippingLabelRepo = shippingLabelRepo;
            _donationContainerRepo = donationContainerRepo;
        }


        public async Task Handle(ShipDonationContainerRequest request, CancellationToken cancellationToken)
        {
            var donationContainer = await _donationContainerRepo.GetAsync(x => x.ReplenishmentOrderId == request.ReplenishmentOrderId, cancellationToken);

            if (donationContainer == null)
            {
                throw new Exception("Container request not found.");
            }

            donationContainer.ApprovedUnits = request.shipmentDetail.ApprovedUnits;
            donationContainer.Status = DonationContainerStatus.Shipped;

            _donationContainerRepo.Update(donationContainer);

            if (request.shipmentDetail.TrackingNumbers.HasItems())
            {
                foreach (var trackingNumber in request.shipmentDetail.TrackingNumbers.Distinct())
                {
                    _shippingLabelRepo.Create(new ShippingLabel
                    {
                        ClinicId = donationContainer.ClinicId,
                        TrackingNumber = trackingNumber
                    });
                }
            }

            await _unitOfwork.SaveAsync(cancellationToken);
        }
    }
}

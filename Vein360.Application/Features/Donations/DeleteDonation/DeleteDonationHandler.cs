using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository;
using Vein360.Application.Repository.DonationsRepository;
using Vein360.Application.Service.ShipmentService;

namespace Vein360.Application.Features.Donations.DeleteDonation
{
    public class DeleteDonationHandler : IRequestHandler<DeleteDonationRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDonationRepository _donationRepo;
        private readonly IShipmentService _shipmentService;

        public DeleteDonationHandler(IUnitOfWork unitOfWork,
                                     IDonationRepository donationRepo,
                                     IShipmentService shipmentService)
        {
            _unitOfWork = unitOfWork;
            _donationRepo = donationRepo;
            _shipmentService = shipmentService;
        }

        public async Task Handle(DeleteDonationRequest request, CancellationToken cancellationToken)
        {
            var donation = await _donationRepo.GetByIdAsync(request.DonationId);


            if (donation.TrackingNumber.IsNotNull())
            {
                await _shipmentService.CancelShipmentAsync(donation.TrackingNumber!.Value);
            }

            _donationRepo.Delete(donation);

            await _unitOfWork.SaveAsync(cancellationToken);

        }
    }
}

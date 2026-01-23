using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Common.Extensions;
using Vein360.Application.Repository;
using Vein360.Application.Repository.DonationsRepository;
using Vein360.Application.Repository.PickupRepository;
using Vein360.Application.Repository.ShippingLabelRepository;
using Vein360.Application.Service.ShipmentService;

namespace Vein360.Application.Features.Donations.DeleteDonation
{
    public class DeleteDonationHandler : IRequestHandler<DeleteDonationRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPickupService _pickupService;
        private readonly IDonationRepository _donationRepo;
        private readonly IShipmentService _shipmentService;
        private readonly IShippingLabelRepository _shippingLabelRepo;


        public DeleteDonationHandler(IUnitOfWork unitOfWork,
                                     IPickupService pickupService,
                                     IDonationRepository donationRepo,
                                     IShipmentService shipmentService,
                                     IShippingLabelRepository shippingLabelRepo)
        {
            _unitOfWork = unitOfWork;
            _donationRepo = donationRepo;
            _pickupService = pickupService;
            _shipmentService = shipmentService;
            _shippingLabelRepo = shippingLabelRepo;
        }

        public async Task Handle(DeleteDonationRequest request, CancellationToken cancellationToken)
        {
            var donation = await _donationRepo.GetAsync(x => x.Id == request.DonationId, cancellationToken, x => x.Include(x => x.Pickup));




            if (DateTime.Now.CompareTo(donation.Pickup.PickupDateTime) < 0) //Current time is earlier than PickupDateTime
            {
                var otherDonationUsingThisPickup = await _donationRepo.IsExistAsync(x => !x.IsDeleted && x.PickupId == donation.PickupId && x.Id != donation.Id);

                if (!otherDonationUsingThisPickup)
                {
                    await _pickupService.CancelPickupSafelyAsync(donation.Pickup.PickupConfirmationCode, donation.Pickup.PickupDateTime);
                    donation.Pickup.MarkAsDeleted();
                }
            }

            if (donation.IsNotProcessed() && donation.TrackingNumber.IsNotNull() && !donation.UseOldLabel)
            {
                await _shipmentService.CancelShipmentSafelyAsync(donation.TrackingNumber!.Value);
            }


            _donationRepo.Delete(donation);


            if (donation.UseOldLabel && donation.TrackingNumber.IsNotNull())
            {
                var shippingLabel = await _shippingLabelRepo.GetAsync(x => x.TrackingNumber == donation.TrackingNumber.Value, cancellationToken);

                shippingLabel.Used = false;

                _shippingLabelRepo.Update(shippingLabel);
            }

            await _unitOfWork.SaveAsync(cancellationToken);

        }
    }
}

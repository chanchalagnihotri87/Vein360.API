using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Features.Donations.Shared;
using Vein360.Application.Features.DonationsFeatures.GetDonorDonations;
using Vein360.Application.Repository;
using Vein360.Application.Repository.DonationsRepository;
using Vein360.Application.Repository.PickupRepository;

namespace Vein360.Application.Features.Donations.ReschedulePickup
{
    public class RescheduleDonationPickupRequestHandler : IRequestHandler<RescheduleDonationPickupRequest, GetDonorDonationsResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPickupRepository _pickupRepo;
        private readonly IDonationRepository _donationRepo;
        private readonly IDonationShippingDetailHandler _donationShippingDetailHandler;


        public RescheduleDonationPickupRequestHandler(IUnitOfWork unitOfWork, IPickupRepository pickupRepo, IDonationRepository donationRepo, IDonationShippingDetailHandler donationShippingDetailHandler)
        {
            _unitOfWork = unitOfWork;
            _pickupRepo = pickupRepo;
            _donationRepo = donationRepo;
            _donationShippingDetailHandler = donationShippingDetailHandler;
        }

        public async Task<GetDonorDonationsResponse> Handle(RescheduleDonationPickupRequest request, CancellationToken cancellationToken)
        {
            //Load donation by id
            var donation = await _donationRepo.GetByIdAsync(request.DonationId, cancellationToken,
                x => x.Include(x => x.Clinic),
                x => x.Include(x => x.Products));


            // If no, recreate shipping detail for donation
            await _donationShippingDetailHandler.HandleAsync(donation.Clinic, donation, cancellationToken);

            await _unitOfWork.SaveAsync(cancellationToken);


            //Load donation with updated pickup and shipment label info
            var updatedDonation = await _donationRepo.GetAsNoTrackingAsync(x => x.Id == request.DonationId, cancellationToken,
                                                                           x => x.Include(x => x.Clinic),
                                                                           x => x.Include(x => x.Pickup),
                                                                           x => x.Include(x => x.Products).ThenInclude(x => x.Product));

            //return donation
            return updatedDonation.Adapt<GetDonorDonationsResponse>();
        }
    }
}

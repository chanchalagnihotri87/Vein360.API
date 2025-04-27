
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository.DonationsRepository;

namespace Vein360.Application.Features.DonationsFeatures.GetDonation
{
    public class GetDonationHandler : IRequestHandler<GetDonationRequest, GetDonationResponse>
    {
        private readonly IDonationRepository _donationRepo;
        public GetDonationHandler(IDonationRepository donationRepo)
        {
            _donationRepo = donationRepo;
        }
        public async Task<GetDonationResponse> Handle(GetDonationRequest request, CancellationToken cancellationToken)
        {
            var donation = await _donationRepo.GetByIdAsync(request.Id, cancellationToken, dnt => dnt.Include(x => x.Products), dnt => dnt.Include(x => x.DonationContainer));

            return donation.Adapt<GetDonationResponse>();
        }
    }
}

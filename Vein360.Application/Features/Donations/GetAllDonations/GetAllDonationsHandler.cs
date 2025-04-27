using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository.DonationsRepository;

namespace Vein360.Application.Features.DonationsFeatures.GetAllDonations
{
    public sealed class GetAllDonationsHandler : IRequestHandler<GetAllDonationsRequest, List<GetAllDonationsResponse>>
    {
        private readonly IDonationRepository _donationRepository;
        public GetAllDonationsHandler(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }

        public async Task<List<GetAllDonationsResponse>> Handle(GetAllDonationsRequest request, CancellationToken cancellationToken)
        {
            var dontaions = await _donationRepository.GetAllAsync(dnt => dnt.Include(x => x.Products).ThenInclude(x => x.Product));

            var response = dontaions.ToList().Adapt<List<GetAllDonationsResponse>>();

            return await Task.FromResult(response);
        }
    }
}

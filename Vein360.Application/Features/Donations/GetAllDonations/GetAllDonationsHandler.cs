using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository.DonationsRepository;
using Vein360.Application.Service.AuthenticationService;

namespace Vein360.Application.Features.DonationsFeatures.GetAllDonations
{
    public sealed class GetAllDonationsHandler : IRequestHandler<GetAllDonationsRequest, List<GetAllDonationsResponse>>
    {
        private readonly IAuthInfoService _authInfoService;
        private readonly IDonationRepository _donationRepository;

        public GetAllDonationsHandler(
            IAuthInfoService authInfoService,
            IDonationRepository donationRepository)
        {
            _authInfoService = authInfoService;
            _donationRepository = donationRepository;
        }

        public async Task<List<GetAllDonationsResponse>> Handle(GetAllDonationsRequest request, CancellationToken cancellationToken)
        {
            var donations = await _donationRepository.GetManyAsync(dnt => dnt.DonorId == _authInfoService.UserId, 
                                                                   cancellationToken, 
                                                                   dnt => dnt.Include(x => x.Products).ThenInclude(x => x.Product));

            var response = donations.OrderByDescending(x=> x.Id).Adapt<List<GetAllDonationsResponse>>();

            return await Task.FromResult(response);
        }
    }
}

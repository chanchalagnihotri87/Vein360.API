using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository.DonationsRepository;
using Vein360.Application.Service.AuthenticationService;

namespace Vein360.Application.Features.DonationsFeatures.GetDonorDonations
{
    public sealed class GetDonorDonationsHandler : IRequestHandler<GetDonorDonationsRequest, List<GetDonorDonationsResponse>>
    {
        private readonly IAuthInfoService _authInfoService;
        private readonly IDonationRepository _donationRepository;
        private readonly ILogger<GetDonorDonationsHandler> _logger;

        public GetDonorDonationsHandler(
            IAuthInfoService authInfoService,
            IDonationRepository donationRepository,
            ILogger<GetDonorDonationsHandler> logger)
        {
            _logger = logger;
            _authInfoService = authInfoService;
            _donationRepository = donationRepository;
            _logger = logger;
        }

        public async Task<List<GetDonorDonationsResponse>> Handle(GetDonorDonationsRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching donations for donor with ID: {UserId}", _authInfoService.UserId);

            var donations = await _donationRepository.GetManyAsync(dnt => dnt.DonorId == _authInfoService.UserId,
                                                                   cancellationToken,
                                                                   dnt => dnt.Include(x => x.Clinic),
                                                                   dnt => dnt.Include(x => x.Pickup),
                                                                   dnt => dnt.Include(x => x.Products).ThenInclude(x => x.Product));

            _logger.LogInformation("Found {DonationCount} donations for donor with ID: {UserId}", donations.Count, _authInfoService.UserId);

            var response = donations.OrderByDescending(x => x.Id).Adapt<List<GetDonorDonationsResponse>>();

            return await Task.FromResult(response);
        }
    }
}

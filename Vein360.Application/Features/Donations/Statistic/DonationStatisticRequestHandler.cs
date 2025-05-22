using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository.DonationsRepository;
using Vein360.Application.Service.AuthenticationService;

namespace Vein360.Application.Features.Donations.Statistic
{
    public class DonationStatisticRequestHandler(IDonationRepository _donationRepo, IAuthInfoService _authInfo) : IRequestHandler<DonationStatisticRequest, DonationStatisticDto>
    {
        public Task<DonationStatisticDto> Handle(DonationStatisticRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_donationRepo.GetStatistic(_authInfo.UserId));
        }
    }
}

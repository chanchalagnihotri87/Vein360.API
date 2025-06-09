using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository.DonationContainerRepository;
using Vein360.Application.Service.AuthenticationService;

namespace Vein360.Application.Features.DonationContainers.GetDonorDonationContainers
{
    public class GetDonorDonationContainersRequestHandler : IRequestHandler<GetDonorDonationContainersRequest, List<DonationConatinerDto>>
    {
        private readonly IAuthInfoService _authInfo;
        private readonly IDonationContainerRepository _donationContainerRepo;

        public GetDonorDonationContainersRequestHandler(IAuthInfoService authInfo,
            IDonationContainerRepository donationContainerRepo)
        {
            _authInfo = authInfo;
            _donationContainerRepo = donationContainerRepo;
        }

        public async Task<List<DonationConatinerDto>> Handle(GetDonorDonationContainersRequest request, CancellationToken cancellationToken)
        {
            var donationContainers = await _donationContainerRepo.GetManyAsync(x => x.DonorId == _authInfo.UserId,
                                                       cancellationToken,
                                                       cnt => cnt.Include(x => x.ContainerType),
                                                       cnt => cnt.Include(x => x.Clinic));

            return donationContainers.Adapt<List<DonationConatinerDto>>();
        }
    }
}

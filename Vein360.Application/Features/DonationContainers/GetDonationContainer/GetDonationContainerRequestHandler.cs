using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository.DonationContainerRepository;

namespace Vein360.Application.Features.DonationContainers.GetDonationContainer
{
    public class GetDonationContainerRequestHandler : IRequestHandler<GetDonationContainerRequest, DonationConatinerDto>
    {
        private readonly IDonationContainerRepository _donationContainerRepo;

        public GetDonationContainerRequestHandler(IDonationContainerRepository donationContainerRepo)
        {
            _donationContainerRepo = donationContainerRepo;
        }

        public async Task<DonationConatinerDto> Handle(GetDonationContainerRequest request, CancellationToken cancellationToken)
        {
            var container = await _donationContainerRepo.GetAsync(x => x.Id == request.Id, cancellationToken,
                x => x.Include(x => x.ContainerType),
                x => x.Include(x => x.Clinic));

            return container.Adapt<DonationConatinerDto>();
        }
    }
}

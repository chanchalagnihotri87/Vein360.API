using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Common.Dtos;
using Vein360.Application.Repository.DonationContainerRepository;

namespace Vein360.Application.Features.DonationContainers.GetAllDonationContainers
{
    public class GetAllDonationContainerHandler : IRequestHandler<GetAllDonationContainerRequest, List<DonationConatinerDto>>
    {
        private readonly IDonationContainerRepository _donationContainerRepo;

        public GetAllDonationContainerHandler(IDonationContainerRepository donationContainerRepo)
        {
            _donationContainerRepo = donationContainerRepo;
        }

        public async Task<List<DonationConatinerDto>> Handle(GetAllDonationContainerRequest request, CancellationToken cancellationToken)
        {
            var containers = await _donationContainerRepo.GetAllAsync(cancellationToken, cnt => cnt.Include(x => x.ContainerType), cnt => cnt.Include(x => x.Container).ThenInclude(y => y.ContainerType));

            return containers.OrderByDescending(x => x.Id).Adapt<List<DonationConatinerDto>>();
        }
    }
}

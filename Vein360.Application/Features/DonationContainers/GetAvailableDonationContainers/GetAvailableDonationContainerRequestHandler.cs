using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Dtos;
using Vein360.Application.Repository.DonationContainerRepository;
using Vien360.Domain.Enums;

namespace Vein360.Application.Features.DonationContainers.GetAvailableDonationContainers
{
    public class GetAvailableDonationContainerRequestHandler : IRequestHandler<GetAvailableDonationContainerRequest, List<DonationConatinerDto>>
    {
        private readonly IDonationContainerRepository _donationContainerRepo;

        public GetAvailableDonationContainerRequestHandler(IDonationContainerRepository donationContainerRepo)
        {
            _donationContainerRepo = donationContainerRepo;
        }

        async Task<List<DonationConatinerDto>> IRequestHandler<GetAvailableDonationContainerRequest, List<DonationConatinerDto>>.Handle(GetAvailableDonationContainerRequest request, CancellationToken cancellationToken)
        {
            var donationContainers = await _donationContainerRepo.GetManyAsync(x => x.Status == DonationContainerStatus.Received, cancellationToken,
                x => x.Include(y => y.ContainerType), x => x.Include(y => y.Container).ThenInclude(z => z.ContainerType));

            return donationContainers.Adapt<List<DonationConatinerDto>>();
        }
    }
}

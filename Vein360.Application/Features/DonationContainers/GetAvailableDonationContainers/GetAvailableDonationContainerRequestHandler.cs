using Microsoft.EntityFrameworkCore;
using Vein360.Application.Repository.DonationContainerRepository;


namespace Vein360.Application.Features.DonationContainers.GetAvailableDonationContainers
{
    public class GetAvailableDonationContainerRequestHandler(IDonationContainerRepository _donationContainerRepo) : IRequestHandler<GetAvailableDonationContainerRequest, List<DonationConatinerDto>>
    {
        async Task<List<DonationConatinerDto>> IRequestHandler<GetAvailableDonationContainerRequest, List<DonationConatinerDto>>.Handle(GetAvailableDonationContainerRequest request, CancellationToken cancellationToken)
        {
            var donationContainers = await _donationContainerRepo.GetManyAsync(x => x.Status == DonationContainerStatus.Approved, 
                                                                               cancellationToken,
                                                                               x => x.Include(y => y.ContainerType));

            return donationContainers.Adapt<List<DonationConatinerDto>>();
        }
    }
}

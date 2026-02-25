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
    public class GetAllDonationContainerHandler : IRequestHandler<GetAllDonationContainerRequest, PagedResponse<DonationConatinerDto>>
    {
        private readonly IDonationContainerRepository _donationContainerRepo;

        public GetAllDonationContainerHandler(IDonationContainerRepository donationContainerRepo)
        {
            _donationContainerRepo = donationContainerRepo;
        }

        public async Task<PagedResponse<DonationConatinerDto>> Handle(GetAllDonationContainerRequest request, CancellationToken cancellationToken)
        {
            var response = new PagedResponse<DonationConatinerDto>();

            var query = _donationContainerRepo.GetAllAsQueryableNoTracking();

            response.CalculateTotalPages(await query.CountAsync());

            response.CalculateSkipCount(request.Page);

            response.Items = query.OrderByDescending(x => x.Id).Skip(response.Skip).Take(response.PageSize).Select(x => new DonationConatinerDto
            {
                Id = x.Id,
                Status = x.Status,
                CreatedDate = x.CreatedDate,
                RequestedUnits = x.RequestedUnits,
                ContainerType = new Vein360ContainerTypeDto
                {
                    Name = x.ContainerType.Name
                }
            });


            return response;

            //var containers = await _donationContainerRepo.GetAllAsync(cancellationToken,
            //                                                          cnt => cnt.Include(x => x.ContainerType),
            //                                                          cnt => cnt.Include(x => x.Clinic));

            //return containers.OrderByDescending(x => x.Id).Adapt<List<DonationConatinerDto>>();
        }
    }
}

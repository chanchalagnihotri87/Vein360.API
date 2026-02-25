using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Common.Helpers.Costants;
using Vein360.Application.Repository.DonationContainerRepository;
using Vein360.Application.Service.AuthenticationService;

namespace Vein360.Application.Features.DonationContainers.GetDonorDonationContainers
{
    public class GetDonorDonationContainersRequestHandler : IRequestHandler<GetDonorDonationContainersRequest, PagedResponse<DonationConatinerDto>>
    {
        private readonly IAuthInfoService _authInfo;
        private readonly IDonationContainerRepository _donationContainerRepo;

        public GetDonorDonationContainersRequestHandler(IAuthInfoService authInfo,
            IDonationContainerRepository donationContainerRepo)
        {
            _authInfo = authInfo;
            _donationContainerRepo = donationContainerRepo;
        }

        public async Task<PagedResponse<DonationConatinerDto>> Handle(GetDonorDonationContainersRequest request, CancellationToken cancellationToken)
        {
            var response = new PagedResponse<DonationConatinerDto>();

            var query = _donationContainerRepo.GetManyAsQueryableNoTracking(x => x.DonorId == _authInfo.UserId);

            response.CalculateTotalPages(await query.CountAsync(cancellationToken));

            response.CalculateSkipCount(request.Page);

            response.Items = query.OrderByDescending(x => x.Id).Skip(response.Skip).Take(response.PageSize).Select(x => new DonationConatinerDto
            {
                Id = x.Id,
                Clinic = new ClinicDto { Id = x.Clinic.Id, ContactName = x.Clinic.ClinicName },
                ContainerType = new Vein360ContainerTypeDto
                {
                    Id = x.Id,
                    Name = x.ContainerType.Name,
                },
                Status = x.Status,
                RequestedUnits = x.RequestedUnits,
                ApprovedUnits = x.ApprovedUnits,
                CreatedDate = x.CreatedDate,

            });


            return response;
        }


    }
}

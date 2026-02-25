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
    public sealed class GetAllDonationsHandler : IRequestHandler<GetAllDonationsRequest, PagedResponse<GetAllDonationsResponse>>
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

        public async Task<PagedResponse<GetAllDonationsResponse>> Handle(GetAllDonationsRequest request, CancellationToken cancellationToken)
        {
            var response = new PagedResponse<GetAllDonationsResponse>();

            var query = _donationRepository.GetAllAsQueryableNoTracking();


            response.CalculateTotalPages(await query.CountAsync());

            response.CalculateSkipCount(request.Page);

            response.Items = query.OrderByDescending(x => x.Id).Skip(response.Skip).Take(response.PageSize).Select(x => new GetAllDonationsResponse
            {
                Id = x.Id,
                TrackingNumber = x.TrackingNumber,
                Status = x.Status,
                CreatedDate = x.CreatedDate,
                Donor = new UserListItemDto
                {
                    Name = x.Donor.Name,
                },
            }).ToHashSet();

            return response;
        }
    }
}

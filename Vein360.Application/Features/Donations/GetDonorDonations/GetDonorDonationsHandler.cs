using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Common.Helpers.Costants;
using Vein360.Application.Repository.DonationsRepository;
using Vein360.Application.Service.AuthenticationService;

namespace Vein360.Application.Features.DonationsFeatures.GetDonorDonations
{
    public sealed class GetDonorDonationsHandler : IRequestHandler<GetDonorDonationsRequest, PagedResponse<GetDonorDonationsResponse>>
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

        public async Task<PagedResponse<GetDonorDonationsResponse>> Handle(GetDonorDonationsRequest request, CancellationToken cancellationToken)
        {
            var response = new PagedResponse<GetDonorDonationsResponse>();

            _logger.LogInformation("Fetching donations for donor with ID: {UserId}", _authInfoService.UserId);

            var query = _donationRepository.GetManyAsQueryableNoTracking(dnt => dnt.DonorId == _authInfoService.UserId);

            response.CalculateTotalPages(await query.CountAsync(cancellationToken));

            response.CalculateSkipCount(request.Page);

            response.Items = await query.OrderByDescending(X => X.Id).Skip(response.Skip).Take(response.PageSize).Select(x => new GetDonorDonationsResponse
            {
                Id = x.Id,
                TrackingNumber = x.TrackingNumber,
                CreatedDate = x.CreatedDate,
                Status = x.Status,
                LabelFileName = x.LabelFileName,
                DonationProducts = x.Products.Select(x => new DonationProductDto
                {
                    Product = new ProductDto
                    {
                        Id = x.Product!.Id,
                        Name = x.Product!.Name,
                        Type = x.Product!.Type,
                        Image = x.Product!.Image
                    },
                    Units = x.Units,
                    Accepted = x.Accepted,
                    Rejected = x.Rejected,
                }),
                Pickup = new PickupDto
                {
                    PickupTransactionId = x.Pickup.PickupTransactionId,
                    PickupConfirmationCode = x.Pickup.PickupConfirmationCode,
                    PickupDateTime = x.Pickup.PickupDateTime
                },
                Clinic = new ClinicDto
                {
                    Id = x.Clinic.Id,
                    ClinicName = x.Clinic.ClinicName,
                    AddressLine1 = x.Clinic.AddressLine1,
                    AddressLine2 = x.Clinic.AddressLine2,
                    City = x.Clinic.City,
                    State = x.Clinic.State,
                    Country = x.Clinic.Country,
                    PostalCode = x.Clinic.PostalCode

                }
            }).ToHashSetAsync(cancellationToken);

            _logger.LogInformation("Found {DonationCount} donations for donor with ID: {UserId}", response.Items.Count(), _authInfoService.UserId);

            return response;
        }
    }
}

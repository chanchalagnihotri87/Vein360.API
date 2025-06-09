using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vein360.Application.Common.Dtos;

using Vein360.Application.Features.Donations.CreateDonation;
using Vein360.Application.Features.Donations.DeleteDonation;
using Vein360.Application.Features.Donations.ProcessDonation;
using Vein360.Application.Features.Donations.SortDonation;
using Vein360.Application.Features.Donations.Statistic;
using Vein360.Application.Features.Donations.UpdateContainerId;
using Vein360.Application.Features.Donations.UpdateDonation;
using Vein360.Application.Features.DonationsFeatures.GetAllDonations;
using Vein360.Application.Features.DonationsFeatures.GetDonation;
using Vein360.Application.Features.DonationsFeatures.GetDonorDonations;

namespace Vein360.API.EndPoints
{
    public record CreateDonationRequestData(int ClinicId, int PackageType, int? ContainerTypeId, int? FedexPackagingTypeId, string TrackingNumber, List<DonationProductItemDto> Products);
    public record UpdateDonationRequestData(int Id, double Amount);
    public record ProcessDonationRequestData(int DonationId, List<ProcessedProductDto> Products);
    public record SortDonationRequestData(List<SortedDonationProductDto> Products, double TotalAmount);

    public static class DonationEndpoints
    {
        public static void MapDonationEndpoints(this WebApplication app)
        {
            app.MapGet("/donations/all", [Authorize] async (IMediator mediator, CancellationToken cancellationToken, HttpContext context) =>
            {
                var donations = await mediator.Send(new GetAllDonationsRequest(), cancellationToken);

                return Results.Ok(donations);
            });

            app.MapGet("/donations", [Authorize] async (IMediator mediator, CancellationToken cancellationToken, HttpContext context) =>
            {
                var donations = await mediator.Send(new GetDonorDonationsRequest(), cancellationToken);

                return Results.Ok(donations);
            });

            app.MapGet("/donations/{id}", [Authorize] async (int id, IMediator mediator, CancellationToken cancellationToken) =>
            {
                var donation = await mediator.Send(new GetDonationRequest { Id = id }, cancellationToken);

                return donation is not null ? Results.Ok(donation) : Results.NotFound();
            });

            app.MapPost("/donations", [Authorize] async ([FromBody] CreateDonationRequestData donation, IMediator mediator) =>
            {
                await mediator.Send(donation.Adapt<CreateDonationRequest>());

                return Results.Ok();
            });

            app.MapPut("/donations", [Authorize] async ([FromBody] UpdateDonationRequestData donation, IMediator mediator) =>
            {
                await mediator.Send(donation.Adapt<UpdateDonationRequest>());

                return Results.Ok();
            });

            app.MapDelete("/donations/{id}", [Authorize] async (int id, IMediator mediator) =>
            {
                await mediator.Send(new DeleteDonationRequest { DonationId = id });

                return Results.Ok();
            });


            app.MapPatch("/donations/process", [Authorize] async ([FromBody] ProcessDonationRequestData request, IMediator mediator) =>
            {
                var response = await mediator.Send(request.Adapt<ProcessDonationRequest>());

                return Results.Ok(response);
            });

            app.MapGet("/donations/statistic", [Authorize] async (IMediator mediator) =>
            {
                var statistic = await mediator.Send(new DonationStatisticRequest());

                return Results.Ok(statistic);
            });

            app.MapPatch("/donations/{trackingNumber}/container/{containerId}", [Authorize] async (long trackingNumber, long containerId, IMediator mediator) =>
            {
                await mediator.Send(new UpdateContainerIdRequest(trackingNumber, containerId));

                return Results.Ok();
            });

            app.MapPatch("/donations/{containerId}/sort", [Authorize] async (long containerId, SortDonationRequestData request, IMediator mediator) =>
            {
                await mediator.Send(new SortDonationRequest(containerId, request.Products, request.TotalAmount));

                return Results.Ok();
            });
        }
    }
}

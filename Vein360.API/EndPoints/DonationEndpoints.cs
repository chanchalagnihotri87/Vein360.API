using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Vein360.API.Erros;
using Vein360.Application.Common.Dtos;
using Vein360.Application.Common.Exceptions;
using Vein360.Application.Features.Donations.CreateDonation;
using Vein360.Application.Features.Donations.DeleteDonation;
using Vein360.Application.Features.Donations.MakePayment;
using Vein360.Application.Features.Donations.ReschedulePickup;
using Vein360.Application.Features.Donations.SortDonation;
using Vein360.Application.Features.Donations.Statistic;
using Vein360.Application.Features.Donations.UpdateContainerId;
using Vein360.Application.Features.Donations.UpdateDonation;
using Vein360.Application.Features.DonationsFeatures.GetAllDonations;
using Vein360.Application.Features.DonationsFeatures.GetDonation;
using Vein360.Application.Features.DonationsFeatures.GetDonorDonations;

namespace Vein360.API.EndPoints
{
    public record CreateDonationRequestData(int ClinicId, string TrackingNumber, List<DonationProductItemDto> Products);
    public record UpdateDonationRequestData(int Id, double Amount);
    public record ProcessDonationRequestData(int DonationId, List<ProcessedProductDto> Products);
    public record SortDonationRequestData(List<SortedDonationProductDto> Products);
    public record PaymentRequestData(DateTime Date, int TransactionType, double Amount);

    public static class DonationEndpoints
    {
        public static void MapDonationEndpoints(this WebApplication app)
        {
            app.MapGet("/donations/all", [Authorize] async (IMediator mediator, CancellationToken cancellationToken, HttpContext context) =>
            {
                var donations = await mediator.Send(new GetAllDonationsRequest(), cancellationToken);

                return Results.Ok(donations);
            });

            app.MapGet("/donations", [Authorize] async (IMediator mediator, ILogger<Program> logger, CancellationToken cancellationToken, HttpContext context) =>
            {
                logger.LogInformation("Entered in donations endpoint");
                
                var donations = await mediator.Send(new GetDonorDonationsRequest(), cancellationToken);

                logger.LogInformation("Exited from donations endpoint");
                
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

            app.MapGet("/donations/statistic", [Authorize] async (IMediator mediator) =>
            {
                var statistic = await mediator.Send(new DonationStatisticRequest());

                return Results.Ok(statistic);
            });

            app.MapPatch("/donations/{id}/pickup/reschedule", [Authorize] async (int id, IMediator mediator) =>
            {
                try
                {
                    var rescheduledDonation = await mediator.Send(new RescheduleDonationPickupRequest(id));

                    return Results.Ok(rescheduledDonation);
                }
                catch (PickupNotAvaliable)
                {
                    var error = new ApiError
                    {
                        StatusCode = 409,
                        Message = "Unable to schedule pickup at this time. Please try again later."
                    };

                    return Results.Json(error, statusCode: 409);
                }
                catch (Exception)
                {
                    throw;
                }



            });


            //Integration with Existing System End Points

            app.MapPatch("/donations/{trackingNumber}/container/{containerId}", [Authorize] async (long trackingNumber, long containerId, IMediator mediator) =>
            {
                await mediator.Send(new UpdateContainerIdRequest(trackingNumber, containerId));

                return Results.Ok();
            });

            app.MapPatch("/donations/{containerId}/sort", [Authorize] async (long containerId, SortDonationRequestData request, IMediator mediator) =>
            {
                await mediator.Send(new SortDonationRequest(containerId, request.Products));

                return Results.Ok();
            });

            app.MapPatch("/donations/{containerId}/payment", [Authorize] async (long containerId, PaymentRequestData request, IMediator mediator) =>
            {
                await mediator.Send(new DonationPaymentRequest(containerId, request.Date, request.TransactionType, request.Amount));

                return Results.Ok();
            });
        }
    }
}

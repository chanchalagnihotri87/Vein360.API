using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vein360.Application.Common.Dtos;
using Vein360.Application.Features.DonationContainers.DeleteDonationContainer;
using Vein360.Application.Features.DonationContainers.GetAllDonationContainers;
using Vein360.Application.Features.DonationContainers.GetAvailableDonationContainers;
using Vein360.Application.Features.DonationContainers.ReceiveDonationContainer;
using Vein360.Application.Features.DonationContainers.RequestForContainer;
using Vein360.Application.Features.Donations.DispatchDonation;

namespace Vein360.API.EndPoints
{
    public static class DonationContainerEndpoints
    {
        public static void MapContainerEndpoints(this WebApplication app)
        {
            app.MapGet("/donationcontainers", [Authorize] async (IMediator mediator, CancellationToken cancellationToken) =>
            {
                var containers = await mediator.Send(new GetAllDonationContainerRequest(), cancellationToken);
                return Results.Ok(containers);
            })
            .WithName("GetAllDonationContainers")
            .Produces<List<DonationConatinerDto>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status500InternalServerError);

            app.MapGet("/donationcontainers/available", [Authorize] async (IMediator mediator, CancellationToken cancellationToken) =>
            {
                var containers = await mediator.Send(new GetAvailableDonationContainerRequest(), cancellationToken);
                return Results.Ok(containers);
            })
           .WithName("GetAvailableDonationContainers")
           .Produces<List<DonationConatinerDto>>(StatusCodes.Status200OK)
           .Produces(StatusCodes.Status500InternalServerError);


            app.MapPost("/donationcontainers/{containerTypeId}", [Authorize] async (int containerTypeId, IMediator mediator, CancellationToken cancellationToken) =>
            {
                await mediator.Send(new RequestForContainerRequest(containerTypeId), cancellationToken);

                return Results.Ok();
            });

            app.MapDelete("/donationcontainers/{id}", [Authorize] async (int id, IMediator mediator, CancellationToken cancellationToken) =>
            {
                await mediator.Send(new DeleteDonationContainerRequest(id), cancellationToken);
                return Results.Ok();
            });

            app.MapPatch("/donationcontainers/receive/{id}", [Authorize] async (int id, IMediator mediator) =>
            {
                await mediator.Send(new ReceiveDonationContainerRequest(id));

                return Results.Ok();
            });
        }
    }
}

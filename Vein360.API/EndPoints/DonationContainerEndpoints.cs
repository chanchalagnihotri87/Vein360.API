using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vein360.Application.Common.Dtos;
using Vein360.Application.Features.DonationContainers.ApproveDonationContainer;
using Vein360.Application.Features.DonationContainers.DeleteDonationContainer;
using Vein360.Application.Features.DonationContainers.GetAllDonationContainers;
using Vein360.Application.Features.DonationContainers.GetAvailableDonationContainers;
using Vein360.Application.Features.DonationContainers.GetDonationContainer;
using Vein360.Application.Features.DonationContainers.RejectDonationContainer;
using Vein360.Application.Features.DonationContainers.RequestForContainer;

namespace Vein360.API.EndPoints
{
    public static class DonationContainerEndpoints
    {
        public static void MapDonationContainerEndpoints(this WebApplication app)
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


            app.MapGet("/donationcontainers/{id}", [Authorize] async (int id, IMediator mediator, CancellationToken cancellationToken) =>
            {
                var containers = await mediator.Send(new GetDonationContainerRequest(id), cancellationToken);
                return Results.Ok(containers);
            })
           .WithName("GetDonationContainer")
           .Produces<DonationConatinerDto>(StatusCodes.Status200OK)
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


            app.MapPatch("/donationcontainers/approve/{id}/{containerId}", [Authorize] async (int id, int containerId, IMediator mediator) =>
            {
                await mediator.Send(new ApproveDonationContainerRequest(id, containerId));
                return Results.Ok();
            });

            app.MapPatch("/donationcontainers/reject/{id}", [Authorize] async (int id, IMediator mediator) =>
            {
                await mediator.Send(new RejectDonationContainerRequest(id));
                return Results.Ok();
            });
        }
    }
}

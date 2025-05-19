using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Vein360.Application.Features.Vein360Containers.CreateContainer;
using Vein360.Application.Features.Vein360Containers.DeleteContainer;
using Vein360.Application.Features.Vein360Containers.GetAllContainers;
using Vein360.Application.Features.Vein360Containers.GetAvailableContainers;
using Vein360.Application.Features.Vein360Containers.UpdateContainer;

namespace Vein360.API.EndPoints
{
    public record CreateContainerRequestData(int ContainerTypeId, string ContainerCode);
    public record UpdateContainerRequestData(int Id, int ContainerTypeId, string ContainerCode, int Status);

    public static class ContainerEndpoints
    {
        public static void MapContainerEndpoints(this WebApplication app)
        {
            app.MapGet("/containers", [Authorize] async (IMediator mediator, CancellationToken cancellationToken) =>
            {

                var containerTypes = await mediator.Send(new GetAllContainersRequest(), cancellationToken);

                return Results.Ok(containerTypes);
            });

            app.MapGet("/containers/available/{containerTypeId}", [Authorize] async (int containerTypeId, IMediator mediator, CancellationToken cancellationToken) =>
            {

                var containerTypes = await mediator.Send(new GetAvailableContainersRequest(containerTypeId), cancellationToken);

                return Results.Ok(containerTypes);
            });



            app.MapPost("/containers", [Authorize] async (IMediator mediator, CreateContainerRequestData request, CancellationToken cancellationToken) =>
            {
                var container = await mediator.Send(request.Adapt<CreateContainerRequest>(), cancellationToken);
                return Results.Created($"/containers/{container.Id}", container);
            });


            app.MapPut("/containers", [Authorize] async (IMediator mediator, UpdateContainerRequestData request, CancellationToken cancellationToken) =>
            {
                var container = await mediator.Send(request.Adapt<UpdateContainerRequest>(), cancellationToken);
                return Results.Ok(container);
            });

            app.MapDelete("/containers/{id}", [Authorize] async (IMediator mediator, int id, CancellationToken cancellationToken) =>
            {
                await mediator.Send(new DeleteContainerRequest(id), cancellationToken);
                return Results.NoContent();
            });
        }
    }
}

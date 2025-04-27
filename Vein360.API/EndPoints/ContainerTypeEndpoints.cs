using MediatR;
using System.Threading;
using Vein360.Application.Features.ContainerTypes.GetAllContainerTypes;

namespace Vein360.API.EndPoints
{
    public static class ContainerTypeEndpoints
    {
        public static void MapContainerTypeEndpoints(this WebApplication app)
        {
            app.MapGet("/containertypes", async (IMediator mediator, CancellationToken cancellationToken) =>{

                var containerTypes = await mediator.Send(new GetAllContainerTypesRequest(), cancellationToken);

                return Results.Ok(containerTypes);
            });
        }
    }
}

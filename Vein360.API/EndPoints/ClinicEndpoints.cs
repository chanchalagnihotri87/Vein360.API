using MediatR;
using Vein360.Application.Features.Clinics.GetClinics;

namespace Vein360.API.EndPoints
{
    public static class ClinicEndpoints
    {
        public static void MapClinicEndpoints(this WebApplication app)
        {
            app.MapGet("/clinics/list", async (IMediator mediator, CancellationToken cancellationToken) =>
            {
                var clinics = await mediator.Send(new GetClinicListRequest(), cancellationToken);

                return Results.Ok(clinics);
            });
        }
    }
}
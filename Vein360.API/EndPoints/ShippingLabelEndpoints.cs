using MediatR;
using Vein360.Application.Features.Labels.GetClinicLabelList;

namespace Vein360.API.EndPoints
{
    public static class ShippingLabelEndpoints
    {
        public static void MapShippingLabelEndpoints(this WebApplication app)
        {
            app.MapGet("/labels/list/{clinicId}", async (int clinicId, IMediator mediator, CancellationToken cancellationToken) =>
           {
               var labels = await mediator.Send(new GetClinicLabelListRequest(clinicId));

               return Results.Ok(labels);
           });
        }
    }
}

using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Vein360.Application.Features.Clinics.CreateClinic;
using Vein360.Application.Features.Clinics.DeleteClinic;
using Vein360.Application.Features.Clinics.GetClinic;
using Vein360.Application.Features.Clinics.GetClinics;
using Vein360.Application.Features.Clinics.UpdateClinic;
using Vein360.Application.Service.AuthenticationService;

namespace Vein360.API.EndPoints
{
    public static class ClinicEndpoints
    {
        public record CreateClinicRequestData(string ClinicName, string ContactName, string ContactEmail, string AddressLine1, string AddressLine2, string City, string State, string Country, string PostalCode, string ContactPhone, int UserId);
        public record UpdateClinicRequestData(int Id, string ClinicName, string ContactName, string ContactEmail, string AddressLine1, string AddressLine2, string City, string State, string Country, string PostalCode, string ContactPhone);

        public static void MapClinicEndpoints(this WebApplication app)
        {
            app.MapGet("/clinics/list", [Authorize] async (IMediator mediator, CancellationToken cancellationToken) =>
            {
                var clinics = await mediator.Send(new GetClinicListRequest(), cancellationToken);

                return Results.Ok(clinics);
            });

            app.MapGet("/clinics/myclinics", [Authorize] async (IMediator mediator, IAuthInfoService authInfo, CancellationToken cancellationToken) =>
            {
                var clinics = await mediator.Send(new GetClinicsRequest(authInfo.UserId), cancellationToken);

                return Results.Ok(clinics);
            });



            app.MapGet("/clinics/{userId}", [Authorize] async (int userId, IMediator mediator, CancellationToken cancellationToken) =>
            {
                var clinics = await mediator.Send(new GetClinicsRequest(userId), cancellationToken);

                return Results.Ok(clinics);
            });

            app.MapGet("/clinics/detail/{id}", [Authorize] async (int id, IMediator mediator, CancellationToken cancellationToken) =>
            {
                var clinics = await mediator.Send(new GetClinicRequest(id), cancellationToken);

                return Results.Ok(clinics);
            });

            app.MapPost("/clinics", [Authorize] async (CreateClinicRequestData request, IMediator mediator) =>
            {
                await mediator.Send(request.Adapt<CreateClinicRequest>());

                return Results.Ok();
            });


            app.MapPut("/clinics", [Authorize] async (UpdateClinicRequestData request, IMediator mediator) =>
            {
                await mediator.Send(request.Adapt<UpdateClinicRequest>());

                return Results.Ok();
            });

            app.MapDelete("/clinics/{id}", [Authorize] async (int id, IMediator mediator) =>
            {
                await mediator.Send(new DeleteClinicRequest(id));

                return Results.Ok();
            });
        }
    }
}
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vein360.Application.Features.Accounts.SingleSignIn;

namespace Vein360.API.EndPoints
{
    public static class SSOEndpoints
    {
        public static void MapSSOEndpoints(this WebApplication app)
        {
            app.MapPost("/sso/donor/signin/{id}", async (string id, IMediator mediator, CancellationToken cancellationToken) =>
            {
                var response = await mediator.Send(new SingleSignInRequest(id, Domain.Enums.RoleType.Donor));
                return Results.Ok(response);
            });

            app.MapPost("/sso/buyer/signin/{id}", async (string id, IMediator mediator, CancellationToken cancellationToken) =>
            {
                var response = await mediator.Send(new SingleSignInRequest(id, Domain.Enums.RoleType.Buyer));
                return Results.Ok(response);
            });

        }
    }
}

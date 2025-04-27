using Mapster;
using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Vein360.Application.Features.Accounts.SignIn;

namespace Vein360.API.EndPoints
{
    public static class AccountEndpoints
    {
        public record SignInRequestData(string Email, string Password);

        public static void MapAccountEndpoints(this WebApplication app)
        {
            app.MapPost("/accounts/signin", async (SignInRequestData request, IMediator mediator) =>
            {
                await mediator.Send(request.Adapt<SignInRequest>());

                return Results.Ok();
            });
        }
    }
}

using MediatR;
using Vein360.Application.Features.Accounts.SignIn;
using Vein360.Domain.Enums;

namespace Vein360.API.EndPoints
{
    public static class AccountEndpoints
    {
        public record SignInRequestData(string Email, string Password);

        public static void MapAccountEndpoints(this WebApplication app)
        {
            app.MapPost("/accounts/admin/signin", async (SignInRequestData requestData, IMediator mediator, IConfiguration configuration) =>
            {
                var request = new SignInRequest(requestData.Email, requestData.Password, RoleType.Admin);

                var token = await mediator.Send(request);

                return Results.Ok(token);
            });

            app.MapPost("/accounts/donor/signin", async (SignInRequestData requestData, IMediator mediator, IConfiguration configuration) =>
            {
                var request = new SignInRequest(requestData.Email, requestData.Password, RoleType.Donor);

                var token = await mediator.Send(request);

                return Results.Ok(token);
            });

            app.MapPost("/accounts/signin", async (SignInRequestData requestData, IMediator mediator, IConfiguration configuration) =>
            {

                var request = new SignInRequest(requestData.Email, requestData.Password, RoleType.Donor);

                var token = await mediator.Send(request);

                return Results.Ok(token);
            });
        }
    }
}

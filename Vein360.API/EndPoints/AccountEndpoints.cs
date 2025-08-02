using MediatR;
using Microsoft.AspNetCore.Authorization;
using Vein360.Application.Common.Dtos;
using Vein360.Application.Common.Exceptions;
using Vein360.Application.Features.Accounts.ChangePassword;
using Vein360.Application.Features.Accounts.SignIn;
using Vein360.Application.Features.DonorPreferences.GetPreferenceByEmail;
using Vein360.Domain.Enums;

namespace Vein360.API.EndPoints
{
    public static class AccountEndpoints
    {
        public record SignInRequestData(string Username, string Password);

        public record ApiSignInRequestData(string Email, string Password);

        public record DonorAuthenticationResponse(string token, bool firstTimeLogin, DonorPreferenceDto Preference);

        public record ChangePasswordRequestData(string currentPassword, string newPassword);

        public static void MapAccountEndpoints(this WebApplication app)
        {
            app.MapPost("/accounts/admin/signin", async (SignInRequestData requestData, IMediator mediator, IConfiguration configuration) =>
            {
                var request = new SignInRequest(requestData.Username, requestData.Password, RoleType.Admin);

                var authResponse = await mediator.Send(request);

                return Results.Ok(authResponse);
            });

            app.MapPost("/accounts/donor/signin", async (SignInRequestData requestData, IMediator mediator, IConfiguration configuration) =>
            {
                var request = new SignInRequest(requestData.Username, requestData.Password, RoleType.Donor);

                var authResponse = await mediator.Send(request);

                var preference = await mediator.Send(new GetDonorPreferenceByEmailRequest(request.username));

                return Results.Ok(new DonorAuthenticationResponse(authResponse.Token, authResponse.FirstTimeLogin, preference));
            });

            app.MapPost("/accounts/buyer/signin", async (SignInRequestData requestData, IMediator mediator, IConfiguration configuration) =>
            {
                var request = new SignInRequest(requestData.Username, requestData.Password, RoleType.Buyer);

                var token = await mediator.Send(request);

                return Results.Ok(token);
            });


            app.MapPost("/accounts/signin", async (ApiSignInRequestData requestData, IMediator mediator, IConfiguration configuration) =>
            {
                var request = new SignInRequest(requestData.Email, requestData.Password, RoleType.ApiUser);

                var token = await mediator.Send(request);

                return Results.Ok(token);
            });


            app.MapPut("/accounts/changepassword", [Authorize] async (ChangePasswordRequestData requestData, IMediator mediator) =>
            {
                try
                {
                    await mediator.Send(new ChangePasswordRequest(requestData.currentPassword, requestData.newPassword));
                }
                catch (CustomValidationException cvEx)
                {
                    return Results.BadRequest(new { CustomError = true, ErrorMessage = cvEx.Message });
                }
                

                return Results.Ok();
            });
        }
    }
}

using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Vein360.Application.Features.Accounts.SignIn;

namespace Vein360.API.EndPoints
{
    public static class AccountEndpoints
    {
        public record SignInRequestData(string Email, string Password);

        public static void MapAccountEndpoints(this WebApplication app)
        {
            app.MapPost("/accounts/signin", async (SignInRequestData request, IMediator mediator, IConfiguration configuration) =>
            {
                await mediator.Send(request.Adapt<SignInRequest>());

                var token = new JwtSecurityToken(
                             claims: new List<Claim> { new Claim(ClaimTypes.Name, "Chanchal") },
                             expires: DateTime.Now.AddDays(1),
                             signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("chanchalchanchalchanchalchanchalchanchalchanchalchanchalchanchal")), SecurityAlgorithms.HmacSha256),
                             issuer: "chanchal",
                             audience: configuration.GetRequiredSection("CorsOrigin").Value!);

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return Results.Ok(tokenString);
            });
        }
    }
}

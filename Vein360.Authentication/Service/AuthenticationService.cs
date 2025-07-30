using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Common.Helpers.Encryption;
using Vein360.Application.Service.AuthenticationService;

namespace Vein360.Authentication.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration configuration;

        public AuthenticationService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GenerateToken(int id,string username, string role )
        {
            var token = new JwtSecurityToken(
            claims: new List<Claim> { 
                new Claim(ClaimTypes.UserData, EncryptionHelper.Encrypt(username)),
                new Claim(ClaimTypes.NameIdentifier, EncryptionHelper.Encrypt(id.ToString())),
                new Claim(ClaimTypes.Role, role)
            },
            expires: DateTime.Now.AddDays(1),
                           signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetRequiredSection("JWTSecret").Value!)), SecurityAlgorithms.HmacSha256),
                           issuer: configuration.GetRequiredSection("JWTIssuer").Value!,
                           audience: configuration.GetRequiredSection("CorsOrigin").Value!);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;

        }
    }
}

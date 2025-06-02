using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Common.Helpers.Encryption;
using Vein360.Application.Service.AuthenticationService;

namespace Vein360.Authentication.Service
{
    public class AuthInfoService : IAuthInfoService
    {
        private readonly HttpContext _httpContext;
        public AuthInfoService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor.HttpContext;
        }

        public int UserId => Convert.ToInt32(EncryptionHelper.Decrypt(GetClaimData(ClaimTypes.NameIdentifier)));

        public string Email => EncryptionHelper.Decrypt(GetClaimData(ClaimTypes.Email));


        private string GetClaimData(string claimType)
        {
            return _httpContext.User.Claims.First(clm => clm.Type == claimType).Value;
        }
    }
}

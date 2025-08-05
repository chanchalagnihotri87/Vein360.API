using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.Accounts.SingleSignIn
{
    public record SingleSignInRequest(string Id, RoleType role) : IRequest<AuthenticationResponseDto>
    {
    }
}

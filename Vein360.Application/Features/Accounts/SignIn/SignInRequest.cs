using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.Accounts.SignIn
{
    public record SignInRequest(string email, string password) : IRequest<string>
    {
    }
}

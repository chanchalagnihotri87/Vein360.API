using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.Users.CreateUser
{
    public record CreateUserRequest(string Email, string Password, bool IsDonor, bool IsAdmin) : IRequest
    {

    }
}

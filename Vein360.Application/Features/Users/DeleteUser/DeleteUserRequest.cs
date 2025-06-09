using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.Users.DeleteUser
{
    public record DeleteUserRequest(int Id) : IRequest
    {
    }
}

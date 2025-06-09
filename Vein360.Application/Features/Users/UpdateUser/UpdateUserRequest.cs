using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.Users.UpdateUser
{
   public record UpdateUserRequest(int Id, string Email, string Test, string Password, bool IsDonor, bool IsAdmin) :IRequest
    {
    }
}

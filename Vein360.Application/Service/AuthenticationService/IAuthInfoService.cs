using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Service.AuthenticationService
{
    public interface IAuthInfoService
    {
        int UserId { get; }
        string Email { get; }
    }
}

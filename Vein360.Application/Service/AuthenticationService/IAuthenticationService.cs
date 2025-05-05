using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Service.AuthenticationService
{
    public interface IAuthenticationService
    {
        string GenerateToken(int id, string email);
    }
}

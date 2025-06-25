using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Common.Dtos
{
    public class AuthenticationResponseDto
    {
        public string Token { get; set; }
        public bool FirstTimeLogin { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.DonorPreferences.GetPreferenceByEmail
{
    public record GetDonorPreferenceByEmailRequest(string email) : IRequest<DonorPreferenceDto>
    {
    }
}

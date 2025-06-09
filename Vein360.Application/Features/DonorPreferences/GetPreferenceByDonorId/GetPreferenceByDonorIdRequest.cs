using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.DonorPreferences.GetPreferenceByDonorId
{
    public record GetPreferenceByDonorIdRequest(int DonorId) : IRequest<DonorPreferenceDto>
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.DonorPreferences.SavePreferences
{
    public record SaveDonorPreferenceRequest(int DonorId, int? defaultClinicId) : IRequest
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.Clinics.GetClinics
{
    public record GetClinicsRequest(int UserId) : IRequest<List<ClinicDto>>
    {
    }
}

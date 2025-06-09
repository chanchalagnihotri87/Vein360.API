using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.Clinics.UpdateClinic
{
    public record UpdateClinicRequest(int Id, string ClinicCode, string ClinicName, string StreetLine, string City, string State, string Country, string PostalCode, string Phone) : IRequest
    {
    }
}

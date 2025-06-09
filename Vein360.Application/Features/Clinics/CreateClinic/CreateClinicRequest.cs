using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.Clinics.CreateClinic
{
    public record CreateClinicRequest(string ClinicCode,
                                      string ClinicName,
                                      string StreetLine,
                                      string City,
                                      string State,
                                      string Country,
                                      string PostalCode,
                                      string Phone,
                                      int UserId) : IRequest
    {
    }
}

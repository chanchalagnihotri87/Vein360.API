using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.Clinics.UpdateClinic
{
    public record UpdateClinicRequest(int Id, 
                                      string ClinicName, 
                                      string ContactName, 
                                      string ContactEmail, 
                                      string ContactPhone, 
                                      string AddressLine1,
                                      string AddressLine2, 
                                      string City, 
                                      string State, 
                                      string Country, 
                                      string PostalCode) : IRequest
    {
    }
}

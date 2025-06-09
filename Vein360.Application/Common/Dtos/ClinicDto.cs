using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Common.Dtos
{
    public class ClinicDto
    {
        public int Id { get; set; }
        public string ClinicCode { get; set; }
        public string ClinicName { get; set; }
        public string StreetLine { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
    }
}

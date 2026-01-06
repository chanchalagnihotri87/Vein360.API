using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Common.Dtos
{
    public record AddressDto
    {
        public List<string> StreetLines { get; set; }
        public string City { get; set; }
        public string StateOrProvinceCode { get; set; }
        public string PostalCode { get; set; }
        public string CountryCode { get; set; }
    }
}

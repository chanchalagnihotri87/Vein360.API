using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Domain.Common
{
    public interface IShippingAddress
    {
        string CompanyName { get; }
        string StreetLine { get; set; }
        string City { get; set; }
         string State { get; set; }
        string Country { get; set; }
        string PostalCode { get; set; }
        string Phone { get; set; }
    }
}

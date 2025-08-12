using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Domain.Common;

namespace Vein360.Shipment
{
    public class Vein360Address : IShippingAddress
    {
        public string CompanyName { get; set; } = "Vein360 LLC";

        public string AddressLine1 { get; set; } = "4460 Lake Forest Drive Suite 230";
        public string AddressLine2 { get; set; } = string.Empty;
        public string City { get; set; } = "Blue Ash";
        public string State { get; set; } = "OH";
        public string Country { get; set; } = "US";
        public string PostalCode { get; set; } = "45242";

        public string Phone { get; set; } = "5134502778";

        public static Vein360Address Initialize()
        {
            return new Vein360Address();
        }
    }
}

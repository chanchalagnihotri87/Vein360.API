using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Domain.Entities
{
    public class Clinic : BaseEntity, IShippingAddress
    {
        public string ClinicCode { get; set; }
        public string ClinicName { get; set; }

        public string StreetLine { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public int UserId { get; set; }

        public Vein360User User { get; set; }

        public string CompanyName
        {
            get
            {
                return ClinicName;
            }
        }

    }
}

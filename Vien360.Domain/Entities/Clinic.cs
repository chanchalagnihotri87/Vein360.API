using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Domain.Entities
{
    public class Clinic : BaseEntity, IShippingAddress
    {
        public string ClinicName { get; set; }
        public string? PrimaryContactName { get; set; }
        public string? PrimaryContactEmail { get; set; }
        public string? PrimaryContactPhone { get; set; }

        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string? PostalCode { get; set; }

        public int UserId { get; set; }

        public Vein360User User { get; set; }

        public string CompanyName
        {
            get
            {
                return ClinicName;
            }
        }

        public string Phone
        {
            get
            {
                return PrimaryContactPhone;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Domain.Entities
{
    public class ShippingLabel : BaseEntity
    {
        public long TrackingNumber { get; set; }
        public int ClinicId { get; set; }
        public bool Used { get; set; }
        public Clinic Clinic { get; set; }
    }
}

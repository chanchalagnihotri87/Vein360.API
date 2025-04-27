using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Shipment
{
    public class CancelShipmentModel
    {
        public AccountNumber AccountNumber { get; set; }
        public long TrackingNumber { get; set; }
        public string DeletionControl { get; set; } = "DELETE_ALL_PACKAGES";

    }
}

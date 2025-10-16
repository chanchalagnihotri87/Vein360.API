using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Shipment.Model
{
    public class PickupResponseModel
    {
        public string transactionId { get; set; }
        public PickupOutput output { get; set; }
    }

    public class PickupOutput
    {
        public string pickupConfirmationCode { get; set; }
    }
}

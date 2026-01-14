using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Shipment.Model
{
    public class CancelPickupModel
    {
        [JsonProperty("associatedAccountNumber")]
        public AccountNumber AssociatedAccountNumber { get; set; }

        [JsonProperty("pickupConfirmationCode")]
        public string PickupConfirmationCode { get; set; }

        [JsonProperty("carrierCode")]
        public string CarrierCode { get; set; }

        [JsonProperty("scheduledDate")]
        public string ScheduledDate { get; set; }
    }
}

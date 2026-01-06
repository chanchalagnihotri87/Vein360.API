using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Shipment.Model
{
    public class PickupAvailabilityModel
    {
        [JsonProperty("pickupAddress")]
        public PickupAvailabilityAddress PickupAddress { get; set; }


        [JsonProperty("pickupRequestType")]
        public List<string> pickupRequestType { get; set; } = new List<string> { "FUTURE_DAY" };

        [JsonProperty("carriers")]
        public List<string> carriers { get; set; } = new List<string> { "FDXG" };

        [JsonProperty("countryRelationship")]
        public string countryRelationship { get; set; } = "DOMESTIC";
    }

    public class PickupAvailabilityAddress
    {
        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Shipment.Model
{
    public class PickupRequestData
    {
        [JsonProperty("associatedAccountNumber")]
        public AccountNumber AssociatedAccountNumber { get; set; }

        [JsonProperty("originDetail")]
        public OriginDetail OriginDetail { get; set; }

        [JsonProperty("carrierCode")]
        public string CarrierCode { get; set; }
    }

    public class OriginDetail
    {
        [JsonProperty("pickupLocation")]
        public PickupLocation PickupLocation { get; set; }

        [JsonProperty("packageLocation")]
        public string PackageLocation { get; set; }

        [JsonProperty("readyDateTimestamp")]
        public string ReadyDateTimestamp { get; set; }

        [JsonProperty("customerCloseTime")]
        public string CustomerCloseTime { get; set; }
    }

    public class PickupLocation
    {
        [JsonProperty("contact")]
        public PickupContact Contact { get; set; }

        [JsonProperty("address")]
        public PickupAddress Address { get; set; }
    }


    public class PickupContact
    {
        [JsonProperty("personName")]
        public string PersonName { get; set; }

        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

        [JsonProperty("phoneNumber")]
        public long PhoneNumber { get; set; }
    }

    public class PickupAddress
    {
        [JsonProperty("streetLines")]
        public List<string> StreetLines { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("stateOrProvinceCode")]
        public string StateOrProvinceCode { get; set; }

        [JsonProperty("postalCode")]
        public long PostalCode { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
    }


}

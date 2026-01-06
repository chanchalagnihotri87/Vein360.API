using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Shipment.Model
{
    public class AddressValidationModel
    {
        [JsonProperty("addressesToValidate")]
        public List<AddressesToValidate> AddressesToValidate { get; set; }
    }

    public class AddressesToValidate
    {
        [JsonProperty("address")]
        public Address Address { get; set; }
    }

    public record Address
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

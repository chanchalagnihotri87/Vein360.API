using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Shipment.Model
{
    public class AddressValidationResponseModel
    {
        public string transactionId { get; set; }
        public AddressValidationOutput output { get; set; }

        public ResolvedAddress Address
        {
            get
            {
                if (output != null && output.resolvedAddresses != null && output.resolvedAddresses.Count > 0)
                {
                    return output.resolvedAddresses[0];
                }
                return null;
            }
        }
    }

    public class Attributes
    {
        public bool POBox { get; set; }
        public string POBoxOnlyZIP { get; set; }
        public string SplitZIP { get; set; }
        public string SuiteRequiredButMissing { get; set; }
        public string InvalidSuiteNumber { get; set; }
        public string ResolutionInput { get; set; }
        public string DPV { get; set; }
        public string ResolutionMethod { get; set; }
        public string DataVintage { get; set; }
        public string MatchSource { get; set; }
        public string CountrySupported { get; set; }
        public string ValidlyFormed { get; set; }
        public string Matched { get; set; }
        public string Resolved { get; set; }
        public string Inserted { get; set; }
        public string MultiUnitBase { get; set; }
        public string ZIP11Match { get; set; }
        public string ZIP4Match { get; set; }
        public string UniqueZIP { get; set; }
        public string StreetAddress { get; set; }
        public string RRConversion { get; set; }
        public string ValidMultiUnit { get; set; }
        public string AddressType { get; set; }
        public string AddressPrecision { get; set; }
        public string MultipleMatches { get; set; }
    }

    public class AddressValidationOutput
    {
        public List<ResolvedAddress> resolvedAddresses { get; set; }
    }

    public class ParsedPostalCode
    {
        public string @base { get; set; }
        public string addOn { get; set; }
        public string deliveryPoint { get; set; }
    }

    public class ResolvedAddress
    {
        public List<string> streetLinesToken { get; set; }
        public string city { get; set; }
        public string stateOrProvinceCode { get; set; }
        public string postalCode { get; set; }
        public ParsedPostalCode parsedPostalCode { get; set; }
        public string countryCode { get; set; }
        public string classification { get; set; }
        public bool ruralRouteHighwayContract { get; set; }
        public bool generalDelivery { get; set; }
        public List<object> customerMessages { get; set; }
        public bool normalizedStatusNameDPV { get; set; }
        public string standardizedStatusNameMatchSource { get; set; }
        public string resolutionMethodName { get; set; }
    }


}

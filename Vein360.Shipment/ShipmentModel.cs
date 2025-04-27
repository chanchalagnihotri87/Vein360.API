using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Vein360.Shipment
{
    public class LabelRequestData
    {
        [JsonProperty("labelResponseOptions")]
        public string LabelResponseOptions { get; set; }

        [JsonProperty("requestedShipment")]
        public RequestedShipment RequestedShipment { get; set; }

        [JsonProperty("accountNumber")]
        public AccountNumber AccountNumber { get; set; }
    }

    public class AccountNumber
    {
        [JsonProperty("value")]
        public long Value { get; set; }
    }

    public class Address
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

        [JsonProperty("residential")]
        public bool Residential { get; set; }
    }

    public class Contact
    {
        [JsonProperty("personName")]
        public string PersonName { get; set; }

        [JsonProperty("phoneNumber")]
        public long PhoneNumber { get; set; }

        [JsonProperty("companyName")]
        public string CompanyName { get; set; }
    }

    public class HomeDeliveryPremiumDetail
    {
        [JsonProperty("homedeliveryPremiumType")]
        public string HomedeliveryPremiumType { get; set; }

        [JsonProperty("deliveryDate")]
        public string DeliveryDate { get; set; }

        [JsonProperty("phoneNumber")]
        public PhoneNumber PhoneNumber { get; set; }
    }

    public class LabelSpecification
    {
        [JsonProperty("imageType")]
        public string ImageType { get; set; }

        [JsonProperty("labelStockType")]
        public string LabelStockType { get; set; }
    }

    public class PhoneNumber
    {
        [JsonProperty("localNumber")]
        public long LocalNumber { get; set; }
    }

    public class Receiver
    {
        [JsonProperty("contact")]
        public Contact Contact { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }
    }

    public class RequestedPackageLineItem
    {
        [JsonProperty("weight")]
        public Weight Weight { get; set; }
    }

    public class RequestedShipment
    {
        [JsonProperty("shipper")]
        public Shipper Shipper { get; set; }

        [JsonProperty("recipients")]
        public List<Receiver> Recipients { get; set; }

        [JsonProperty("shipDatestamp")]
        public string ShipDatestamp { get; set; }

        [JsonProperty("serviceType")]
        public string ServiceType { get; set; }

        [JsonProperty("packagingType")]
        public string PackagingType { get; set; }

        [JsonProperty("pickupType")]
        public string PickupType { get; set; }

        [JsonProperty("blockInsightVisibility")]
        public bool BlockInsightVisibility { get; set; }

        [JsonProperty("shippingChargesPayment")]
        public ShippingChargesPayment ShippingChargesPayment { get; set; }

        //[JsonProperty("shipmentSpecialServices")]
        //public ShipmentSpecialServices ShipmentSpecialServices { get; set; }

        [JsonProperty("labelSpecification")]
        public LabelSpecification LabelSpecification { get; set; }

        [JsonProperty("requestedPackageLineItems")]
        public List<RequestedPackageLineItem> RequestedPackageLineItems { get; set; }
    }

    public class ShipmentSpecialServices
    {
        [JsonProperty("specialServiceTypes")]
        public List<string> SpecialServiceTypes { get; set; }

        [JsonProperty("homeDeliveryPremiumDetail")]
        public HomeDeliveryPremiumDetail HomeDeliveryPremiumDetail { get; set; }
    }

    public class Shipper
    {
        [JsonProperty("contact")]
        public Contact Contact { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }
    }

    public class ShippingChargesPayment
    {
        [JsonProperty("paymentType")]
        public string PaymentType { get; set; }
    }

    public class Weight
    {
        [JsonProperty("units")]
        public string Units { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }
    }


}


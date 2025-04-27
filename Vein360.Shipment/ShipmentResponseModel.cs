using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Shipment
{



    public class ShipmentResponseModel
    {
        public string transactionId { get; set; }

        public string customerTransactionId { get; set; }


        public Output output { get; set; }

        public string trackingNumber =>
            output?.transactionShipments?.FirstOrDefault()?.completedShipmentDetail?.completedPackageDetails.FirstOrDefault()?.trackingIds.FirstOrDefault()?.trackingNumber;

        public string encodedLabelData =>
    output?.transactionShipments?.FirstOrDefault()?.pieceResponses?.FirstOrDefault()?.packageDocuments.FirstOrDefault().encodedLabel.ToString();

        public string labelTrackingNumber =>
    output?.transactionShipments?.FirstOrDefault()?.pieceResponses?.FirstOrDefault()?.trackingNumber;

        public string masterTrackingNumber => output?.transactionShipments?.FirstOrDefault()?.pieceResponses.FirstOrDefault()?.masterTrackingNumber;
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Alert
    {
        [JsonProperty("code")]
        public string code { get; set; }

        [JsonProperty("message")]
        public string message { get; set; }

        [JsonProperty("alertType")]
        public string alertType { get; set; }
    }

    public class Barcodes
    {
        [JsonProperty("binaryBarcodes")]
        public List<BinaryBarcode> binaryBarcodes { get; set; }

        [JsonProperty("stringBarcodes")]
        public List<StringBarcode> stringBarcodes { get; set; }
    }

    public class BillingWeight
    {
        [JsonProperty("units")]
        public string units { get; set; }

        [JsonProperty("value")]
        public int value { get; set; }
    }

    public class BinaryBarcode
    {
        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("value")]
        public string value { get; set; }
    }

    public class CompletedPackageDetail
    {
        [JsonProperty("sequenceNumber")]
        public int sequenceNumber { get; set; }

        [JsonProperty("trackingIds")]
        public List<TrackingId> trackingIds { get; set; }

        [JsonProperty("groupNumber")]
        public int groupNumber { get; set; }

        //[JsonProperty("packageRating")]
        //public PackageRating packageRating { get; set; }

        [JsonProperty("signatureOption")]
        public string signatureOption { get; set; }

        [JsonProperty("operationalDetail")]
        public OperationalDetail operationalDetail { get; set; }
    }

    public class CompletedShipmentDetail
    {
        [JsonProperty("usDomestic")]
        public bool usDomestic { get; set; }

        [JsonProperty("carrierCode")]
        public string carrierCode { get; set; }

        [JsonProperty("masterTrackingId")]
        public MasterTrackingId masterTrackingId { get; set; }

        [JsonProperty("serviceDescription")]
        public ServiceDescription serviceDescription { get; set; }

        [JsonProperty("packagingDescription")]
        public string packagingDescription { get; set; }

        [JsonProperty("operationalDetail")]
        public OperationalDetail operationalDetail { get; set; }

        //[JsonProperty("shipmentRating")]
        //public ShipmentRating shipmentRating { get; set; }

        [JsonProperty("completedPackageDetails")]
        public List<CompletedPackageDetail> completedPackageDetails { get; set; }
    }

    public class MasterTrackingId
    {
        [JsonProperty("trackingIdType")]
        public string trackingIdType { get; set; }

        [JsonProperty("trackingNumber")]
        public string trackingNumber { get; set; }
    }

    public class Name
    {
        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("encoding")]
        public string encoding { get; set; }

        [JsonProperty("value")]
        public string value { get; set; }
    }

    public class OperationalDetail
    {
        [JsonProperty("originLocationNumber")]
        public int originLocationNumber { get; set; }

        [JsonProperty("destinationLocationNumber")]
        public int destinationLocationNumber { get; set; }

        [JsonProperty("deliveryDate")]
        public string deliveryDate { get; set; }

        [JsonProperty("deliveryDay")]
        public string deliveryDay { get; set; }

        [JsonProperty("ineligibleForMoneyBackGuarantee")]
        public bool ineligibleForMoneyBackGuarantee { get; set; }

        [JsonProperty("serviceCode")]
        public string serviceCode { get; set; }

        [JsonProperty("packagingCode")]
        public string packagingCode { get; set; }

        [JsonProperty("deliveryEligibilities")]
        public List<string> deliveryEligibilities { get; set; }

        [JsonProperty("transitTime")]
        public string transitTime { get; set; }

        [JsonProperty("publishedDeliveryTime")]
        public string publishedDeliveryTime { get; set; }

        [JsonProperty("scac")]
        public string scac { get; set; }

        [JsonProperty("barcodes")]
        public Barcodes barcodes { get; set; }

        [JsonProperty("astraHandlingText")]
        public string astraHandlingText { get; set; }

        [JsonProperty("operationalInstructions")]
        public List<OperationalInstruction> operationalInstructions { get; set; }
    }

    public class OperationalInstruction
    {
        [JsonProperty("number")]
        public int number { get; set; }

        [JsonProperty("content")]
        public string content { get; set; }
    }

    public class Output
    {
        [JsonProperty("transactionShipments")]
        public List<TransactionShipment> transactionShipments { get; set; }
    }

    public class PackageDocument
    {
        [JsonProperty("contentType")]
        public string contentType { get; set; }

        [JsonProperty("copiesToPrint")]
        public int copiesToPrint { get; set; }

        [JsonProperty("encodedLabel")]
        public string encodedLabel { get; set; }

        [JsonProperty("docType")]
        public string docType { get; set; }

        public string url { get; set; }
    }

    public class PackageRateDetail
    {
        [JsonProperty("rateType")]
        public string rateType { get; set; }

        [JsonProperty("ratedWeightMethod")]
        public string ratedWeightMethod { get; set; }

        [JsonProperty("minimumChargeType")]
        public string minimumChargeType { get; set; }

        [JsonProperty("billingWeight")]
        public BillingWeight billingWeight { get; set; }

        [JsonProperty("baseCharge")]
        public double baseCharge { get; set; }

        [JsonProperty("totalFreightDiscounts")]
        public double totalFreightDiscounts { get; set; }

        [JsonProperty("netFreight")]
        public double netFreight { get; set; }

        [JsonProperty("totalSurcharges")]
        public double totalSurcharges { get; set; }

        [JsonProperty("netFedExCharge")]
        public double netFedExCharge { get; set; }

        [JsonProperty("totalTaxes")]
        public double totalTaxes { get; set; }

        [JsonProperty("netCharge")]
        public double netCharge { get; set; }

        [JsonProperty("totalRebates")]
        public double totalRebates { get; set; }

        [JsonProperty("surcharges")]
        public List<Surcharge> surcharges { get; set; }

        [JsonProperty("currency")]
        public string currency { get; set; }
    }

    public class PackageRating
    {
        [JsonProperty("actualRateType")]
        public string actualRateType { get; set; }

        [JsonProperty("effectiveNetDiscount")]
        public int effectiveNetDiscount { get; set; }

        [JsonProperty("packageRateDetails")]
        public List<PackageRateDetail> packageRateDetails { get; set; }
    }

    public class PieceResponse
    {
        [JsonProperty("masterTrackingNumber")]
        public string masterTrackingNumber { get; set; }

        [JsonProperty("deliveryDatestamp")]
        public string deliveryDatestamp { get; set; }

        [JsonProperty("trackingNumber")]
        public string trackingNumber { get; set; }

        [JsonProperty("additionalChargesDiscount")]
        public double additionalChargesDiscount { get; set; }

        [JsonProperty("netRateAmount")]
        public double netRateAmount { get; set; }

        [JsonProperty("netChargeAmount")]
        public double netChargeAmount { get; set; }

        [JsonProperty("netDiscountAmount")]
        public double netDiscountAmount { get; set; }

        [JsonProperty("packageDocuments")]
        public List<PackageDocument> packageDocuments { get; set; }

        [JsonProperty("currency")]
        public string currency { get; set; }

        [JsonProperty("customerReferences")]
        public List<object> customerReferences { get; set; }

        [JsonProperty("codcollectionAmount")]
        public double codcollectionAmount { get; set; }

        [JsonProperty("baseRateAmount")]
        public double baseRateAmount { get; set; }
    }

    public class ServiceDescription
    {
        [JsonProperty("serviceId")]
        public string serviceId { get; set; }

        [JsonProperty("serviceType")]
        public string serviceType { get; set; }

        [JsonProperty("code")]
        public string code { get; set; }

        [JsonProperty("names")]
        public List<Name> names { get; set; }

        [JsonProperty("operatingOrgCodes")]
        public List<string> operatingOrgCodes { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("astraDescription")]
        public string astraDescription { get; set; }
    }

    public class ShipmentAdvisoryDetails
    {
    }

    public class ShipmentRateDetail
    {
        //[JsonProperty("rateType")]
        //public string rateType { get; set; }

        //[JsonProperty("rateScale")]
        //public string rateScale { get; set; }

        //[JsonProperty("rateZone")]
        //public string rateZone { get; set; }

        //[JsonProperty("ratedWeightMethod")]
        //public string ratedWeightMethod { get; set; }

        //[JsonProperty("dimDivisor")]
        //public int dimDivisor { get; set; }

        //[JsonProperty("fuelSurchargePercent")]
        //public double fuelSurchargePercent { get; set; }

        //[JsonProperty("totalBillingWeight")]
        //public TotalBillingWeight totalBillingWeight { get; set; }

        //[JsonProperty("totalBaseCharge")]
        //public double totalBaseCharge { get; set; }

        //[JsonProperty("totalFreightDiscounts")]
        //public int totalFreightDiscounts { get; set; }

        //[JsonProperty("totalNetFreight")]
        //public double totalNetFreight { get; set; }

        //[JsonProperty("totalSurcharges")]
        //public double totalSurcharges { get; set; }

        //[JsonProperty("totalNetFedExCharge")]
        //public double totalNetFedExCharge { get; set; }

        //[JsonProperty("totalTaxes")]
        //public int totalTaxes { get; set; }

        //[JsonProperty("totalNetCharge")]
        //public double totalNetCharge { get; set; }

        //[JsonProperty("totalRebates")]
        //public int totalRebates { get; set; }

        //[JsonProperty("totalDutiesAndTaxes")]
        //public int totalDutiesAndTaxes { get; set; }

        //[JsonProperty("totalAncillaryFeesAndTaxes")]
        //public int totalAncillaryFeesAndTaxes { get; set; }

        //[JsonProperty("totalDutiesTaxesAndFees")]
        //public int totalDutiesTaxesAndFees { get; set; }

        //[JsonProperty("totalNetChargeWithDutiesAndTaxes")]
        //public int totalNetChargeWithDutiesAndTaxes { get; set; }

        //[JsonProperty("surcharges")]
        //public List<Surcharge> surcharges { get; set; }

        //[JsonProperty("freightDiscounts")]
        //public List<object> freightDiscounts { get; set; }

        //[JsonProperty("taxes")]
        //public List<object> taxes { get; set; }

        //[JsonProperty("currency")]
        //public string currency { get; set; }
    }

    public class ShipmentRating
    {
        [JsonProperty("actualRateType")]
        public string actualRateType { get; set; }

        //[JsonProperty("shipmentRateDetails")]
        //public List<ShipmentRateDetail> shipmentRateDetails { get; set; }
    }

    public class StringBarcode
    {
        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("value")]
        public string value { get; set; }
    }

    public class Surcharge
    {
        [JsonProperty("surchargeType")]
        public string surchargeType { get; set; }

        [JsonProperty("level")]
        public string level { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("amount")]
        public double amount { get; set; }
    }

    public class TotalBillingWeight
    {
        [JsonProperty("units")]
        public string units { get; set; }

        [JsonProperty("value")]
        public double value { get; set; }
    }

    public class TrackingId
    {
        [JsonProperty("trackingIdType")]
        public string trackingIdType { get; set; }

        [JsonProperty("trackingNumber")]
        public string trackingNumber { get; set; }
    }

    public class TransactionShipment
    {
        [JsonProperty("alerts")]
        public List<Alert> alerts { get; set; }

        [JsonProperty("masterTrackingNumber")]
        public string masterTrackingNumber { get; set; }

        [JsonProperty("serviceType")]
        public string serviceType { get; set; }

        [JsonProperty("shipDatestamp")]
        public string shipDatestamp { get; set; }

        [JsonProperty("serviceName")]
        public string serviceName { get; set; }

        [JsonProperty("pieceResponses")]
        public List<PieceResponse> pieceResponses { get; set; }

        [JsonProperty("shipmentAdvisoryDetails")]
        public ShipmentAdvisoryDetails shipmentAdvisoryDetails { get; set; }

        [JsonProperty("completedShipmentDetail")]
        public CompletedShipmentDetail completedShipmentDetail { get; set; }

        [JsonProperty("serviceCategory")]
        public string serviceCategory { get; set; }
    }


}




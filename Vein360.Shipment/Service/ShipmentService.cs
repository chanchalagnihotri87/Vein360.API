using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Vein360.Application.Common.Dtos;
using Vein360.Application.Common.Extensions;
using Vein360.Application.Service.ShipmentService;
using Vein360.Domain.Common;
using Vein360.Domain.Enums;
using Vein360.Shipment.Helper;
using Vein360.Shipment.Model;

namespace Vein360.Shipment.Service
{
    public class ShipmentService : IShipmentService
    {
        private readonly IFedexAuthHelper _fedexAuthHelper; 
        private readonly ILogger<IShipmentService> _logger;
        public ShipmentService(IFedexAuthHelper fedexAuthHelper, ILogger<IShipmentService> logger)
        {
            _logger= logger;
            _fedexAuthHelper = fedexAuthHelper;
        }


        public async Task<ShipmentDetailDto> CreateDonationShipmentAsync(double weight, IShippingAddress senderAddress, AddressDto formattedSenderAddress, string shipDate )
        {
            // Build Label Request Data
            LabelRequestData labelRequestData = BuildLabelRequestData(senderAddress, formattedSenderAddress, Vein360Address.Initialize(), shipDate, weight: weight);


            // Call FedEx Shipment API
            var client = await _fedexAuthHelper.GetAuthorizedHttpClientAsync();
            var response = await client.PostAsJsonAsync("/ship/v1/shipments", labelRequestData);
            var responseString = await response.Content.ReadAsStringAsync();


            // Handle non-success response
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("FedEx Shipment API Error: {ResponseString}. Request Data: {RequestData}", responseString, JsonSerializer.Serialize(labelRequestData));

                throw new InvalidOperationException($"FedEx error on Create Shipment using Shipment API Error: {responseString}. Request Data: {JsonSerializer.Serialize(labelRequestData)}");
            }

            // Deserialize response
            var data = JsonSerializer.Deserialize<ShipmentResponseModel>(responseString);


            // Return Shipment Detail
            return new ShipmentDetailDto
            {
                TransactionId = data.transactionId,
                MasterTrackingNumber = data.masterTrackingNumber,
                TrackingNumber = data.trackingNumber,
                EncodedLabel = data.encodedLabelData,
                LabelUrl = data.labelUrl,
                LabelTrackingNumber = data.labelTrackingNumber
            };


        }

        // Private Methods
        private LabelRequestData BuildLabelRequestData(IShippingAddress senderAddress, AddressDto formattedSenderAddress, IShippingAddress receiverAddress, string shipDate, string packagingType = "YOUR_PACKAGING", double weight = 10)
        {

            var labelRequestData = new LabelRequestData();
            labelRequestData.LabelResponseOptions = "URL_ONLY";

            labelRequestData.RequestedShipment = new RequestedShipment();

            labelRequestData.RequestedShipment.Shipper = new Shipper
            {
                Contact = new Contact
                {
                    PersonName = "",
                    CompanyName = senderAddress.CompanyName,
                    PhoneNumber = senderAddress.Phone.RemovePhoneFormat().IsNotNullOrEmpty() ? Convert.ToInt64(senderAddress.Phone.RemovePhoneFormat()) : default
                },
                Address = new ShipmentAddress
                {
                    StreetLines = formattedSenderAddress.StreetLines,
                    City = formattedSenderAddress.City,
                    StateOrProvinceCode = formattedSenderAddress.StateOrProvinceCode,
                    PostalCode = formattedSenderAddress.PostalCode,
                    CountryCode = formattedSenderAddress.CountryCode
                }
            };

            labelRequestData.RequestedShipment.Recipients = [ new Receiver
            {
                Contact = new Contact
                {
                    PersonName = "",
                    CompanyName = receiverAddress.CompanyName,
                    PhoneNumber = Convert.ToInt64(receiverAddress.Phone)
                },
                Address = new ShipmentAddress
                {
                    StreetLines = new List<string>
                    {
                      receiverAddress.AddressLine1
                    },
                    City = receiverAddress.City,
                    StateOrProvinceCode = receiverAddress.State,
                    PostalCode = receiverAddress.PostalCode,
                    CountryCode = receiverAddress.Country
                }
            }];


            labelRequestData.RequestedShipment.ShipDatestamp = shipDate;
            labelRequestData.RequestedShipment.ServiceType = "FEDEX_GROUND";
            labelRequestData.RequestedShipment.PackagingType = packagingType;
            labelRequestData.RequestedShipment.PickupType = "USE_SCHEDULED_PICKUP";
            labelRequestData.RequestedShipment.BlockInsightVisibility = false;
            labelRequestData.RequestedShipment.ShippingChargesPayment = new ShippingChargesPayment
            {
                PaymentType = "SENDER",
            };

            labelRequestData.RequestedShipment.LabelSpecification = new LabelSpecification
            {
                ImageType = "PDF",
                LabelStockType = "PAPER_85X11_TOP_HALF_LABEL"
            };

            labelRequestData.RequestedShipment.RequestedPackageLineItems = new List<RequestedPackageLineItem>
            {
                new RequestedPackageLineItem
                {
                    Weight = new Weight
                    {
                        Value = Convert.ToInt32(Math.Ceiling(weight)),
                        Units = "LB"
                    }
                }
            };

            labelRequestData.AccountNumber = new AccountNumber
            {
                Value = _fedexAuthHelper.AccountNumber
            };

            return labelRequestData;
        }

        public async Task CancelShipmentAsync(long trackingNumber)
        {
            // Build Cancel Shipment Request Data
            var requestData = new CancelShipmentModel
            {
                AccountNumber = new AccountNumber { Value = _fedexAuthHelper.AccountNumber },
                TrackingNumber = trackingNumber
            };

            // Call FedEx Shipment Cancel API
            var client = await _fedexAuthHelper.GetAuthorizedHttpClientAsync();
            var response = await client.PutAsJsonAsync("/ship/v1/shipments/cancel", requestData);

            var responseString = await response.Content.ReadAsStringAsync();


            // Handle non-success response
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("FedEx Shipment Cancel API Error: {ResponseString}. Request Data: {RequestData}", responseString, JsonSerializer.Serialize(requestData));

                throw new InvalidOperationException($"FedEx error on Create Shipment using Shipment API Error: {responseString}. Request Data: {JsonSerializer.Serialize(requestData)}");
            }


            // Handle non-success response
            response.EnsureSuccessStatusCode();
        }

        public Task CancelShipmentSafelyAsync(long trackingNumber)
        {
            try
            {
                // Attempt to cancel the shipment
                return CancelShipmentAsync(trackingNumber);
            }
            catch
            {
                // Swallow any exceptions to ensure safe cancellation
                return Task.CompletedTask;
            }
        }

    }
}

using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Vein360.Application.Common.Dtos;
using Vein360.Application.Common.Extensions;
using Vein360.Application.Service.ShipmentService;
using Vein360.Domain.Common;
using Vein360.Domain.Enums;

namespace Vein360.Shipment.Service
{
    public class ShipmentService : IShipmentService
    {
        private readonly FedexCredential fedexCredential;
        public ShipmentService(FedexCredential fedexCredential)
        {
            this.fedexCredential = fedexCredential;
        }


        public async Task<ShipmentDetailDto> CreateDonationShipmentAsync(double weight, IShippingAddress senderAddress)
        {
            var tokenData = await AuthorizeAsync(fedexCredential.ClientId, fedexCredential.ClientSecret);

            LabelRequestData labelRequestData = GetLabelRequestData(senderAddress, Vein360Address.Initialize(), weight: weight);

            ShipmentDetailDto shipmentDetail = await CreateShipmentAsync(tokenData.access_token, labelRequestData);

            return shipmentDetail;
        }


        private LabelRequestData GetLabelRequestData(IShippingAddress senderAddress, IShippingAddress receiverAddress, string packagingType = "YOUR_PACKAGING", double weight = 10)
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
                Address = new Address
                {
                    StreetLines = new List<string> { senderAddress.AddressLine1 },
                    City = senderAddress.City,
                    StateOrProvinceCode = senderAddress.State,
                    PostalCode = Convert.ToInt64(senderAddress.PostalCode),
                    CountryCode = senderAddress.Country
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
                Address = new Address
                {
                    StreetLines = new List<string>
                    {
                      receiverAddress.AddressLine1
                    },
                    City = receiverAddress.City,
                    StateOrProvinceCode = receiverAddress.State,
                    PostalCode =Convert.ToInt64(receiverAddress.PostalCode),
                    CountryCode = receiverAddress.Country
                }
            }];


            labelRequestData.RequestedShipment.ShipDatestamp = DateTime.Now.ToString("yyyy-MM-dd");
            labelRequestData.RequestedShipment.ServiceType = "FEDEX_GROUND";
            labelRequestData.RequestedShipment.PackagingType = packagingType; //"YOUR_PACKAGING";
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
                Value = fedexCredential.AccountNumber
            };

            return labelRequestData;
        }

        private async Task<ShipmentDetailDto> CreateShipmentAsync(string accessToken, LabelRequestData labelRequestData)
        {
            ShipmentDetailDto shipmentDetail = null;

            try
            {
                var client = new HttpClient { BaseAddress = new Uri(fedexCredential.ApiUrl) };
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var response = await client.PostAsJsonAsync("/ship/v1/shipments", labelRequestData);
                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<ShipmentResponseModel>(content);
                if (data != null)
                {
                    shipmentDetail = new ShipmentDetailDto
                    {
                        TransactionId = data.transactionId,
                        MasterTrackingNumber = data.masterTrackingNumber,
                        TrackingNumber = data.trackingNumber,
                        EncodedLabel = data?.encodedLabelData,
                        LabelUrl = data?.labelUrl,
                        LabelTrackingNumber = data?.labelTrackingNumber
                    };
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return shipmentDetail;
        }



        public async Task CancelShipmentAsync(long trackingNumber)
        {
            var tokenData = await AuthorizeAsync(fedexCredential.ClientId, fedexCredential.ClientSecret);

            var requestData = new CancelShipmentModel
            {
                AccountNumber = new AccountNumber { Value = fedexCredential.AccountNumber },
                TrackingNumber = trackingNumber
            };

            var client = new HttpClient { BaseAddress = new Uri(fedexCredential.ApiUrl) };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenData.access_token);
            var response = await client.PutAsJsonAsync("/ship/v1/shipments/cancel", requestData);

            response.EnsureSuccessStatusCode();
        }


        private async Task<TokenDto> AuthorizeAsync(string clientId, string clientSecret)
        {
            try
            {

                var data = new Dictionary<string, string>{
                                {"grant_type", "client_credentials"},
                                {"client_id", clientId},
                                {"client_secret", clientSecret} };


                var client = new HttpClient { BaseAddress = new Uri(fedexCredential.ApiUrl) };

                var response = await client.PostAsync("/oauth/token", new FormUrlEncodedContent(data));

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<TokenDto>(content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

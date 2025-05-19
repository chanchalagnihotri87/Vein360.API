using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Vein360.Application.Common.Dtos;
using Vein360.Application.Service.ShipmentService;
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


        public async Task<ShipmentDetailDto> CreateDonationShipmentAsync(ContainerType containerType, int? containerId, double weight)
        {
            var tokenData = await AuthorizeAsync(fedexCredential.ClientId, fedexCredential.ClientSecret);

            LabelRequestData labelRequestData = CreateContainerLabelRequestData(containerType, containerId, weight);

            ShipmentDetailDto shipmentDetail = await CreateShipmentAsync(tokenData.access_token, labelRequestData);

            return shipmentDetail;


            //Local Methods
            LabelRequestData CreateContainerLabelRequestData(ContainerType containerType, int? containerId, double weight)
            {
                LabelRequestData labelRequestData = null;

                if (containerType == ContainerType.FedexContainer)
                {
                    string packagingType = FedexHelper.GetFedexPackagingCode(containerId.Value);
                    weight = FedexHelper.GetFedexPackageWeight(containerId.Value);


                    labelRequestData = GetLabelRequestData(packagingType, weight);
                }
                else
                {
                    labelRequestData = GetLabelRequestData(weight: weight);
                }

                return labelRequestData;
            }


        }

        public async Task<ShipmentDetailDto> CreateDonationContainerShipmentAsync(double weight)
        {
            var tokenData = await AuthorizeAsync(fedexCredential.ClientId, fedexCredential.ClientSecret);

            LabelRequestData labelRequestData = GetLabelRequestData(weight: weight);

            ShipmentDetailDto shipmentDetail = await CreateShipmentAsync(tokenData.access_token, labelRequestData);

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

            var client = new HttpClient { BaseAddress = new Uri("https://apis-sandbox.fedex.com") };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenData.access_token);
            var response = await client.PutAsJsonAsync("/ship/v1/shipments/cancel", requestData);

            response.EnsureSuccessStatusCode();
        }

        #region Private Methods

        private LabelRequestData GetLabelRequestData(string packagingType = "YOUR_PACKAGING", double weight = 10)
        {

            var labelRequestData = new LabelRequestData();
            labelRequestData.LabelResponseOptions = "URL_ONLY";

            labelRequestData.RequestedShipment = new RequestedShipment();


            labelRequestData.RequestedShipment.Shipper = new Shipper
            {
                Contact = new Contact
                {
                    PersonName = "SHIPPER NAME",
                    CompanyName = "Shipper Company Name",
                    PhoneNumber = 9012638716
                },
                Address = new Address
                {
                    StreetLines = new List<string> { "SHIPPER STREET LINE 1" },
                    City = "HARRISON",
                    StateOrProvinceCode = "AR",
                    PostalCode = 72601,
                    CountryCode = "US"
                }
            };


            labelRequestData.RequestedShipment.Recipients = [ new Receiver
            {
                Contact = new Contact
                {
                    PersonName = "RECIPIENT NAME",
                    CompanyName = "Recipient Company Name",
                    PhoneNumber = 9012638716
                },
                Address = new Address
                {
                    StreetLines = new List<string>
                    {
                      "RECIPIENT STREET LINE 1",
                     "RECIPIENT STREET LINE 2"
                    },
                    City = "Collierville",
                    StateOrProvinceCode = "TN",
                    PostalCode = 38017,
                    CountryCode = "US"
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
                var client = new HttpClient { BaseAddress = new Uri("https://apis-sandbox.fedex.com") };
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


        private async Task<TokenDto> AuthorizeAsync(string clientId, string clientSecret)
        {
            try
            {

                var data = new Dictionary<string, string>{
                                {"grant_type", "client_credentials"},
                                {"client_id", clientId},
                                {"client_secret", clientSecret} };


                var client = new HttpClient { BaseAddress = new Uri("https://apis-sandbox.fedex.com") };

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


        #endregion
    }
}

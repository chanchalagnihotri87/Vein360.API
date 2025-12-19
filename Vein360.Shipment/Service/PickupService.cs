using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;
using Vein360.Application.Common.Dtos;
using Vein360.Application.Common.Extensions;
using Vein360.Application.Service.ShipmentService;
using Vein360.Domain.Common;
using Vein360.Shipment.Helper;
using Vein360.Shipment.Model;

namespace Vein360.Shipment.Service
{
    public class PickupService : IPickupService
    {
        private readonly IFedexAuthHelper fedexAuthHelper;

        public PickupService(IFedexAuthHelper fedexAuthHelper)
        {
            this.fedexAuthHelper = fedexAuthHelper;
        }

        public async Task<ShipmentPickupDetailDto> CreatePickupAsync(IShippingAddress senderAddress)
        {
            PickupRequestData pickupRequestData = GetPickupRequestData(senderAddress);

            try
            {
                var pickupResponseString = await CreateFedexPickup(pickupRequestData);

                var pickupResponse = JsonSerializer.Deserialize<PickupResponseModel>(pickupResponseString);

                if (pickupResponse == null || pickupResponse.output == null)
                {
                    throw new InvalidOperationException("The pickup response or its output is null.");
                }

                return new ShipmentPickupDetailDto
                {
                    TransactionId = pickupResponse.transactionId,
                    ConfirmationCode = pickupResponse.output.pickupConfirmationCode,
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<string> CreateFedexPickup(PickupRequestData pickupRequestData)
        {
            var tokenData = await fedexAuthHelper.GetAccessTokenAsync();

            var client = new HttpClient { BaseAddress = new Uri(fedexAuthHelper.ApiUrl) };

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenData.access_token);

            var response = await client.PostAsJsonAsync("/pickup/v1/pickups", pickupRequestData);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        private PickupRequestData GetPickupRequestData(IShippingAddress receiverAddress)
        {
            var pickupRequestData = new PickupRequestData();
            pickupRequestData.AssociatedAccountNumber = new AccountNumber { Value = fedexAuthHelper.AccountNumber };

            pickupRequestData.CarrierCode = "FDXG";
            pickupRequestData.OriginDetail = new OriginDetail
            {
                PackageLocation = "FRONT",
                ReadyDateTimestamp = GetNextFedExWorkingDay(DateTime.Now.AddDays(2).Date.AddHours(14)).ToString("yyyy-MM-ddTHH:mm:ssZ"),
                CustomerCloseTime = "17:00:00",
                PickupLocation = new PickupLocation
                {
                    Contact = new PickupContact
                    {
                        PersonName = receiverAddress.CompanyName,
                        PhoneNumber = receiverAddress.Phone.RemovePhoneFormat().IsNotNullOrEmpty() ? Convert.ToInt64(receiverAddress.Phone.RemovePhoneFormat()) : default
                    },
                    Address = new PickupAddress
                    {
                        StreetLines = new List<string> { receiverAddress.AddressLine1 },
                        City = receiverAddress.City,
                        StateOrProvinceCode = receiverAddress.State,
                        PostalCode = Convert.ToInt64(receiverAddress.PostalCode),
                        CountryCode = receiverAddress.Country
                    }
                }
            };

            return pickupRequestData;
        }

        private DateTime GetNextFedExWorkingDay(DateTime date)
        {
            date = date.Date;

            // Skip Sunday
            if (date.DayOfWeek == DayOfWeek.Sunday)
                date = date.AddDays(1);

            return date;
        }
    }
}

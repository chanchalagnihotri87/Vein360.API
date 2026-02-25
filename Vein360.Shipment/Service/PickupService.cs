using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;
using Vein360.Application.Common.Dtos;
using Vein360.Application.Common.Exceptions;
using Vein360.Application.Common.Extensions;
using Vein360.Domain.Common;using Vein360.Application.Service.ShipmentService;

using Vein360.Domain.Entities;
using Vein360.Shipment.Helper;
using Vein360.Shipment.Model;

namespace Vein360.Shipment.Service
{
    public class PickupService : IPickupService                                                                                                                                                                                                     
    {
        private readonly IFedexAuthHelper fedexAuthHelper;

        private ILogger<PickupService> _logger;

        public PickupService(IFedexAuthHelper fedexAuthHelper, ILogger<PickupService> logger)
        {
            this.fedexAuthHelper = fedexAuthHelper;
            this._logger = logger;
        }


        public async Task<ShipmentPickupDetailDto> CreatePickupAsync(IShippingAddress senderAddress, IEnumerable<IPickupTime> availablePickupTimes, AddressDto formattedAddress)
        {

            // Try each available pickup time to create pickup until one succeeds
            foreach (var pickupTime in availablePickupTimes.OrderBy(x => x.ReadyDateTime))
            {
                PickupRequestData pickupRequestData = BuildPickupRequestData(senderAddress, pickupTime, formattedAddress);

                // Call FedEx Pickup API
                var client = await fedexAuthHelper.GetAuthorizedHttpClientAsync();
                var response = await client.PostAsJsonAsync("/pickup/v1/pickups", pickupRequestData);
                var responseString = await response.Content.ReadAsStringAsync();

                // Retry if is is a Not_Working_Day error otherwise throw exception
                if (!response.IsSuccessStatusCode)
                {

                    var pickupError = JsonSerializer.Deserialize<PickupErrorResponseModel>(responseString);

                    // If it's a not working day error, try the next available pickup time
                    if (pickupError!.IsNotWorkingDayError || pickupError.GroundServicesUnavailableError)
                    {
                        continue;
                    }

                    _logger.LogError($"FedEx Pickup API Error on Creating Pickup: {responseString}. Request Data: {JsonSerializer.Serialize(pickupRequestData)}");

                    throw new FedexApiException($"FedEx Error on Creating Pickup using Pickup API Error: {responseString}. Request Data: {JsonSerializer.Serialize(pickupRequestData)}");
                }


                // Deserialize pickup response
                var pickupResponse = JsonSerializer.Deserialize<PickupResponseModel>(responseString);

                // Validate pickup response
                if (pickupResponse.IsNull() || pickupResponse.output.IsNull()) { throw new FedexApiException("The pickup response or its output is null."); }


                // Return successful pickup detail
                return new ShipmentPickupDetailDto
                {
                    TransactionId = pickupResponse.transactionId,
                    ConfirmationCode = pickupResponse.output.pickupConfirmationCode,
                    PickupTime = pickupTime
                };

            }

            // If all available pickup times failed to create pickup, throw exception
            _logger.LogError("No pickup option available. All attempts to create pickup failed. Times {Times}", JsonSerializer.Serialize(availablePickupTimes));

            throw new PickupNotAvaliable();




            // Local function
            PickupRequestData BuildPickupRequestData(IShippingAddress receiverAddress, IPickupTime pickupTimeInfo, AddressDto formattedAddress)
            {
                var pickupRequestData = new PickupRequestData();
                pickupRequestData.AssociatedAccountNumber = new AccountNumber { Value = fedexAuthHelper.AccountNumber };

                pickupRequestData.CarrierCode = "FDXG";
                pickupRequestData.OriginDetail = new OriginDetail
                {
                    PackageLocation = "FRONT",
                    ReadyDateTimestamp = pickupTimeInfo.ReadyDateTimeString,
                    CustomerCloseTime = pickupTimeInfo.CloseTime,
                    PickupLocation = new PickupLocation
                    {
                        Contact = new PickupContact
                        {
                            PersonName = "Front Desk",
                            CompanyName = receiverAddress.CompanyName,
                            PhoneNumber = receiverAddress.Phone.RemovePhoneFormat().IsNotNullOrEmpty() ? Convert.ToInt64(receiverAddress.Phone.RemovePhoneFormat()) : default
                        },
                        Address = new PickupAddress
                        {
                            StreetLines = formattedAddress.StreetLines,
                            City = formattedAddress.City,
                            StateOrProvinceCode = formattedAddress.StateOrProvinceCode,
                            PostalCode = formattedAddress.PostalCode,
                            CountryCode = formattedAddress.CountryCode
                        }
                    }
                };

                return pickupRequestData;
            }
        }

        public async Task CancelPickupAsync(string pickupConfirmationCode, DateTime pickupDateTime)
        {
            // Build cancel pickup request data
            var cancelPickupRequestData = new CancelPickupModel
            {
                CarrierCode = "FDXG",
                AssociatedAccountNumber = new AccountNumber { Value = fedexAuthHelper.AccountNumber },
                PickupConfirmationCode = pickupConfirmationCode,
                ScheduledDate = pickupDateTime.ToString("yyyy-MM-dd")
            };


            // Call FedEx Pickup API
            var client = await fedexAuthHelper.GetAuthorizedHttpClientAsync();
            var response = await client.PutAsJsonAsync("/pickup/v1/pickups/cancel", cancelPickupRequestData);
            var responseString = await response.Content.ReadAsStringAsync();

            // Handle cancel pickup response
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"FedEx Pickup API Error on Canceling Pickup: {responseString} \n\n Request Data: {JsonSerializer.Serialize(cancelPickupRequestData)}");

                throw new InvalidOperationException($"FedEx Error on Canceling Pickup using Pickup API. \n Error: {responseString} \n\n Request Data: {JsonSerializer.Serialize(cancelPickupRequestData)}");
            }

        }
        public async Task CancelPickupSafelyAsync(string pickupConfirmationCode, DateTime pickupDateTime)
        {
            try
            {
                // Attempt to cancel the pickup
                await CancelPickupAsync(pickupConfirmationCode, pickupDateTime);
            }
            catch (Exception)
            {
                //Log cancel pickup error

                // Swallow the exception to ensure safe cancellation
            }
        }

        public async Task<IEnumerable<AvailableTimeDto>> CheckPickupAvailability(string postalCode, string countryCode)
        {
            // Build pickup availability request data
            var pickupAvailabilityRequestData = new PickupAvailabilityModel
            {
                PickupAddress = new PickupAvailabilityAddress { PostalCode = postalCode, CountryCode = countryCode }
            };

            // Call FedEx Pickup Availability API
            var client = await fedexAuthHelper.GetAuthorizedHttpClientAsync();
            var response = await client.PostAsJsonAsync($"/pickup/v1/pickups/availabilities", pickupAvailabilityRequestData);
            var responseString = await response.Content.ReadAsStringAsync();


            // Handle pickup availability response
            if (!response.IsSuccessStatusCode)
            {

                throw new InvalidOperationException($"FedEx Pickup API Error: {responseString}. Request Data: {JsonSerializer.Serialize(pickupAvailabilityRequestData)}");
            }
            var availabilityResponse = JsonSerializer.Deserialize<PickupAvailabilityResponseModel>(responseString);

            if (availabilityResponse.IsNull() || availabilityResponse!.output.options.IsEmpty()) { return []; }


            // Filter suitable availability options
            var suitableOptions = new FedexPickupAvailabilityHelper(availabilityResponse.output.options).GetSuitableAvailabilityOptions(); ;

            if (suitableOptions.IsEmpty())
            {
                return [];
            }

            // Map to AvailableTimeDto and return
            return suitableOptions.Select(suitableOption => new AvailableTimeDto
            {
                ReadyDateString = suitableOption.PickupDate,
                ReadyDateTimeString = suitableOption.PickupDateTime,
                CloseTime = FedexPickupAvailabilityHelper.DefaultClinicCloseTime.TimeString
            }).OrderBy(x => x.ReadyDateTime);
        }



    }
}

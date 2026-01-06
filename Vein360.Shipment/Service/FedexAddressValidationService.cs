using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Service.ShipmentService;
using Vein360.Domain.Common;
using Vein360.Shipment.Helper;
using Vein360.Shipment.Model;
using Vein360.Application.Common.Extensions;
using Vein360.Application.Common.Dtos;
using System.Text.Json;

namespace Vein360.Shipment.Service
{
    public class FedexAddressValidationService : IAddressValidationService
    {
        private readonly IFedexAuthHelper fedexAuthHelper;

        public FedexAddressValidationService(IFedexAuthHelper fedexAuthHelper)
        {
            this.fedexAuthHelper = fedexAuthHelper;
        }

        public async Task<AddressDto> ValidateAddressAsync(IShippingAddress address)
        {

            var validateAddressRequestData = new AddressValidationModel
            {
                AddressesToValidate = new List<AddressesToValidate>
                {
                    new AddressesToValidate
                    {
                        Address = new Address
                        {
                            StreetLines = new List<string> { address.AddressLine1 },
                            City = address.City,
                            StateOrProvinceCode = address.State,
                            PostalCode = Convert.ToInt64(address.PostalCode),
                            CountryCode = address.Country
                        }
                    }
                }
            };

            var client = await fedexAuthHelper.GetAuthorizedHttpClientAsync();

            var response = await client.PostAsJsonAsync("/address/v1/addresses/resolve", validateAddressRequestData);

            var responseString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException($"FedEx Pickup API > Validate Pickup Address Error: {responseString} \n\n Request Data: {JsonSerializer.Serialize(validateAddressRequestData)}");
            }

            var addressResponse = JsonSerializer.Deserialize<AddressValidationResponseModel>(responseString);


            if (addressResponse.IsNotNull() && addressResponse.Address.IsNotNull())
            {
                return new AddressDto
                {
                    StreetLines = addressResponse.Address.streetLinesToken,
                    City = addressResponse.Address.city,
                    StateOrProvinceCode = addressResponse.Address.stateOrProvinceCode,
                    PostalCode = addressResponse.Address.postalCode.ToString(),
                    CountryCode = addressResponse.Address.countryCode
                };
            }

            return null;

        }
    }
}

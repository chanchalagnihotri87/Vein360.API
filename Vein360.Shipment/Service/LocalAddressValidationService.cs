using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Common.Dtos;
using Vein360.Application.Service.ShipmentService;
using Vein360.Domain.Common;

namespace Vein360.Shipment.Service
{
    public class LocalAddressValidationService : IAddressValidationService
    {
        public Task<AddressDto> ValidateAddressAsync(IShippingAddress address)
        {
            return Task.FromResult(new AddressDto
            {
                StreetLines = new List<string> { address.AddressLine1 },
                City = address.City,
                StateOrProvinceCode = address.State,
                PostalCode = address.PostalCode,
                CountryCode = address.Country
            });
        }
    }
}

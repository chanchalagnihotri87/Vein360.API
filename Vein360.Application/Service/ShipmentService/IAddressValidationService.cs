using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Domain.Common;

namespace Vein360.Application.Service.ShipmentService
{
    public interface IAddressValidationService
    {
        Task<AddressDto> ValidateAddressAsync(IShippingAddress address);
    }
}

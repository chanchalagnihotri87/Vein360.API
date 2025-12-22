using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Domain.Common;

namespace Vein360.Application.Service.ShipmentService
{
    public interface IPickupService
    {
        Task<ShipmentPickupDetailDto> CreatePickupAsync(IShippingAddress senderAddress);
        Task CancelPickupAsync(string pickupConfirmationCode, DateTime pickupDateTime);
        Task CancelPickupSafelyAsync(string pickupConfirmationCode, DateTime pickupDateTime);
        DateTime GetPickupDateTime();
    }
}

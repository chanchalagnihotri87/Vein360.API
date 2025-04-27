using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Dtos;
using Vien360.Domain.Enums;

namespace Vein360.Application.Service.ShipmentService
{
    public interface IShipmentService
    {
        Task<ShipmentDetailDto> CreateShipmentAsync(ContainerType containerType, int containerId, int weight);
        Task CancelShipmentAsync(long trackingNumber);
    }
}

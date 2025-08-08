using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.Orders.UpdateOrderClinicAndQuantity
{
    public record UpdateOrderClinicAndQuantityRequest(int OrderId, int ClinicId, int Quantity) : IRequest<OrderDto>
    {
    }
}

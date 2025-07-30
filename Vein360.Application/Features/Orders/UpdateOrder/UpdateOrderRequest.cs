using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.Orders.UpdateOrder
{
    public record UpdateOrderRequest(int OrderId, int ProductId, int ClinicId, decimal Price, OrderStatus Status) : IRequest<OrderDto>
    {
    }
}

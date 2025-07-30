using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.Orders.GetAllOrders
{
    public record GetAllOrdersRequest : IRequest<List<OrderDto>>
    {
    }
}

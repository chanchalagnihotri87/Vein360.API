using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.Orders.CreateOrder
{
    public record CreateOrderRequest(int ProductId, int ClinicId, int Quantity) : IRequest
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.Orders.UpdateOrderClinic
{
    public record UpdateOrderClinicRequest(int OrderId, int ClinicId) : IRequest<OrderDto>
    {
    }
}

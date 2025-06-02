using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.Donations.UpdateContainerId
{
    public record UpdateContainerIdRequest(long trackingNumber, long containerId) : IRequest
    {
    }
}

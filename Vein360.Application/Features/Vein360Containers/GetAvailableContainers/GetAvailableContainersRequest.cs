using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.Vein360Containers.GetAvailableContainers
{
    public record GetAvailableContainersRequest(int ContainerTypeId):IRequest<IEnumerable<ContainerDto>>
    {
    }
}

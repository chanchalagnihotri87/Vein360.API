using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.Vein360Containers.CreateContainer
{
    public record CreateContainerRequest(int ContainerTypeId, string ContainerCode):IRequest<ContainerDto>
    {
    }
}

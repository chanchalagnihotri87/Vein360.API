using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.DonationContainers.RequestForContainer
{
    public record RequestForContainerRequest(int ContainerTypeId) : IRequest
    {
    }
}

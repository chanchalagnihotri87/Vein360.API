using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.DonationContainers.DeleteDonationContainer
{
    public record DeleteDonationContainerRequest(int ContainerId):IRequest
    {
    }
}

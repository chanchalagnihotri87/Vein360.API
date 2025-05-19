using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.DonationContainers.GetDonationContainer
{
    public record GetDonationContainerRequest(int Id) : IRequest<DonationConatinerDto>
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.DonationContainers.ShipDonationContainer
{
    public record ShipDonationContainerRequest(long ReplenishmentOrderId, ShippedDonationContainerDto shipmentDetail) : IRequest
    {
    }
}

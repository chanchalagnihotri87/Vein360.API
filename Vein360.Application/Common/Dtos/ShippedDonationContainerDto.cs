using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Common.Dtos
{
    public class ShippedDonationContainerDto
    {
        public int ApprovedUnits { get; set; }
        public List<long> TrackingNumbers { get; set; }
    }
}

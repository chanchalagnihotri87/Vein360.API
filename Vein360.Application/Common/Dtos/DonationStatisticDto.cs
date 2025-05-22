using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Common.Dtos
{
    public class DonationStatisticDto
    {
        public int TotalProducts { get; set; }
        public int AcceptedProducts { get; set; }
        public int RejectedProducts { get; set; }
    }
}

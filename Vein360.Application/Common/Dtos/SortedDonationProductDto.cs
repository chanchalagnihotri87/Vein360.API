using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Common.Dtos
{
    public class SortedDonationProductDto
    {
        public int ProductId { get; set; }
        public int AcceptedUnits { get; set; }
        public int RejectedClogged { get; set; }
        public int RejectedDamaged { get; set; }
        public int RejectedFunction { get; set; }
        public int RejectedKinked { get; set; }
        public int RejectedOther { get; set; }
    }
}

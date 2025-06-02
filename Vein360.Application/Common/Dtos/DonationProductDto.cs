using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Common.Dtos
{
    public class DonationProductDto: DonationProductItemDto
    {
        public int Id { get; set; }
        public int DonationId { get; set; }
        public int Accepted { get; set; }
        public int Rejected { get; set; }
        public int RejectedClogged { get; set; }
        public int RejectedDamaged { get; set; }
        public int RejectedFunction { get; set; }
        public int RejectedKinked { get; set; }
        public int RejectedOther { get; set; }
    }
}

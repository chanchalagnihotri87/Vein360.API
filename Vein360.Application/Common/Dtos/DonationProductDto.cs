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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Common.Dtos
{
    public class ProductRateDto
    {
        public int ProductId { get; set; }
        public double? Price { get; set; }
        public bool UseSalesCredit { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Common.Dtos
{
    public class UserProductDto : ProductDto
    {
        public int Id { get; set; }
        public double SellingPrice { get; set; }
        public double BuyingPrice { get; set; }
        public bool IncludedInContract { get; set; }
    }
}

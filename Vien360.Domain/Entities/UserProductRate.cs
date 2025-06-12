using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Domain.Entities
{
    public class UserProductRate : BaseEntity
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public double? SellingPrice { get; set; }
        public bool PayToSalesCredit { get; set; }
        public double? BuyingPrice { get; set; }
        public bool PayFromSalesCredit { get; set; }

        public Vein360User User { get; set; }   
    }
}

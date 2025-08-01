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
        public double? Price { get; set; }
        public bool UseSalesCredit { get; set; }
        
        public Vein360User User { get; set; }   
        public Product Product { get; set; }
    }
}

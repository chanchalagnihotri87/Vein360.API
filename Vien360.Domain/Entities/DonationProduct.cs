using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vien360.Domain.Entities
{
   public class DonationProduct
    {
        public int Id { get; set; }
        public int DonationId { get; set; }
        public int ProductId { get; set; }
        public int Units { get; set; }
        public Donation Donation { get; set; }
        public Product Product { get; set; }
    }
}

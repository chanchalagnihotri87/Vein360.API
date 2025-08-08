using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; } = 1;
        public int ClinicId { get; set; }
        public decimal Price { get; set; }
        public int UserId { get; set; }
        public bool Paid { get; set; }
        public OrderStatus Status { get; set; }
        public Product Product { get; set; }
        public Clinic Clinic { get; set; }
        public Vein360User User { get; set; }

        public decimal TotalAmount
        {
            get
            {
                return Price * Quantity;
            }
        }
    }
}

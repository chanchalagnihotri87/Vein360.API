using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Common.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public ProductDto Product { get; set; }
        public ClinicListItemDto Clinic { get; set; }
        public decimal Price { get; set; }
        public bool Paid { get; set; }
        public OrderStatus Status { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public int UserId { get; set; }
    }
}

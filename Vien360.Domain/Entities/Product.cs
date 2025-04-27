using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vien360.Domain.Common;
using Vien360.Domain.Enums;

namespace Vien360.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        
        public decimal Price { get; set; }
        public ProductType Type { get; set; }
    }
}

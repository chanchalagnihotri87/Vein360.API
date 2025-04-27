using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vien360.Domain.Common;
using Vien360.Domain.Enums;

namespace Vien360.Domain.Entities
{
    public class Vein360ContainerType : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int Capacity { get; set; }
    }
}

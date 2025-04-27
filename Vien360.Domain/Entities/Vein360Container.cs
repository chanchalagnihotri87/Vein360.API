using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vien360.Domain.Common;
using Vien360.Domain.Enums;

namespace Vien360.Domain.Entities
{
    public class Vein360Container : BaseEntity
    {
        public int ContainerTypeId { get; set; }
        public Vein360ContainerStatus Status { get; set; }
        public string ContainerCode { get; set; }
        public Vein360ContainerType ContainerType { get; set; }

       
    }
}

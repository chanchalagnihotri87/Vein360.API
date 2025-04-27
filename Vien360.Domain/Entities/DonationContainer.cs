using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vien360.Domain.Common;
using Vien360.Domain.Enums;

namespace Vien360.Domain.Entities
{
    public class DonationContainer : BaseEntity
    {
        public int ContainerTypeId { get; set; }
        public int? ContainerId { get; set; }
        public long? TrackingNumber { get; set; }
        public DonationContainerStatus Status { get; set; }
        public int DonorId { get; set; }

        public Vein360ContainerType? ContainerType { get; set; }
        public Vein360Container? Container { get; set; }
    }
}

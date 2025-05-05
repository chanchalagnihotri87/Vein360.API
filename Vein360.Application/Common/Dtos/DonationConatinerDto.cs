using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vien360.Domain.Enums;

namespace Vein360.Application.Common.Dtos
{
    public class DonationConatinerDto
    {
        public int Id { get; set; }
        public int ContainerTypeId { get; set; }
        public int? ContainerId { get; set; }
        public long? TrackingNumber { get; set; }
        public int DonorId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DonationContainerStatus Status { get; set; }
        public required Vein360ContainerTypeDto ContainerType { get; set; }
        public Vein360ContainerDto? Container { get; set; }



    }
}

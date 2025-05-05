using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Common.Dtos;
using Vien360.Domain.Enums;

namespace Vein360.Application.Features.DonationsFeatures.GetDonation
{
    public record GetDonationResponse
    {
        public int Id { get; set; }
        public ContainerType ContainerType { get; set; }       
        public int ContainerId { get; set; }
        public long? TrackingNumber { get; set; }
        public DonationConatinerDto Container { get; set; }
        public int Weight { get; set; } // in pounds
        public ICollection<DonationProductDto> Products { get; set; }
    }
}

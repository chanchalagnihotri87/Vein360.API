using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Dtos;
using Vien360.Domain.Enums;

namespace Vein360.Application.Features.Donations.CreateDonation
{
    public record CreateDonationRequest : IRequest
    {
        public ContainerType ContainerType { get; set; }
        public int ContainerId { get; set; }
        public int Weight { get; set; } // in pounds
        public List<DonationProductItemDto> Products { get; set; }
    }
}

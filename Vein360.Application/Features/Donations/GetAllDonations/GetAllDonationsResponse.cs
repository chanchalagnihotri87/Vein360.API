using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vien360.Domain.Enums;

namespace Vein360.Application.Features.DonationsFeatures.GetAllDonations
{
    public sealed record GetAllDonationsResponse
    {
        private const string API_URL = "https://localhost:7303";
        public int Id { get; set; }
        public int ContainerId { get; set; }
        public ContainerType ContainerType { get; set; }
        public List<string> ProductTypes { get; set; }
        public long? TrackingNumber { get; set; }
        public string? LabelFileName { get; set; }
        public string? LabelPath
        {
            get
            {
                return $"{API_URL}/label/{LabelFileName}";
            }
        }
        public DonationStatus Status { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}

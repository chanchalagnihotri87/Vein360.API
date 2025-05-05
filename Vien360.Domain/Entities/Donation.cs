using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application;
using Vien360.Domain.Common;
using Vien360.Domain.Enums;

namespace Vien360.Domain.Entities
{
    public class Donation : BaseEntity
    {
        public ContainerType ContainerType { get; set; }
        public int? DonationContainerId { get; set; }
        public int? FedexContainerId { get;set; }
        public string? FedexTransactionId { get; set; }
        public long? MasterTrackingNumber { get; set; }
        public long? TrackingNumber { get; set; }
        public string? LabelFileName { get; set; }
        public DonationStatus Status { get; set; }
        public int Weight { get; set; } // in pounds
        public int DonorId { get; set; }
        public DonationContainer? DonationContainer { get; set; }
        public required ICollection<DonationProduct> Products { get; set; }
        public Vein360User Donor { get; set; }

        public List<string> ProductTypes
        {
            get
            {
                if (Products.Count != 0)
                {
                    return [.. this.Products.Select(x => x.Product.Type.ToDescriptionString()).Distinct()];
                }

                return [];
            }
        }

    }
}

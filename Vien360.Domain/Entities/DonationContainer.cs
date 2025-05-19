using System.ComponentModel;

namespace Vein360.Domain.Entities
{
    public class DonationContainer : BaseEntity
    {
        public int ContainerTypeId { get; set; }
        public int? ContainerId { get; set; }

        public string? FedexTransactionId { get; set; }
        public long? MasterTrackingNumber { get; set; }
        public long? TrackingNumber { get; set; }
        public string? LabelFileName { get; set; }

        public DonationContainerStatus Status { get; set; }
        public int DonorId { get; set; }

        public Vein360ContainerType? ContainerType { get; set; }
        public Vein360Container? Container { get; set; }
        public Vein360User? Donor { get; set; }

        public void MarkAsFilled()
        {
            Status = DonationContainerStatus.Filled;
        }

        public void MarkAsProcessed()
        {
            Status = DonationContainerStatus.Processed;
            Container.MarkAsAvailable();
        }

        public void MarkAsApproved()
        {
            Status = DonationContainerStatus.Approved;
            Container.MarkAsAssigned();
        }

        public void MarkAsUnfilled() {
            this.MarkAsApproved();
        }
    }
}

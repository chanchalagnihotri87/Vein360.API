using System.ComponentModel;

namespace Vein360.Domain.Entities
{
    public class DonationContainer : BaseEntity
    {
        public int ContainerTypeId { get; set; }
        public int ClinicId { get; set; }
        public int RequestedUnits { get; set; }
        public int? ApprovedUnits { get; set; }
        public long? ReplenishmentOrderId { get; set; }

        public DonationContainerStatus Status { get; set; }
        public int DonorId { get; set; }

        public Vein360ContainerType? ContainerType { get; set; }
        public Vein360User? Donor { get; set; }

        public Clinic? Clinic { get; set; }
     
        public void MarkAsApproved()
        {
            Status = DonationContainerStatus.Approved;

        }
    }
}

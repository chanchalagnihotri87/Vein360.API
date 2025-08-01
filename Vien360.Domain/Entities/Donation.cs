using Vein360.Domain.Enums.Extensions;


namespace Vein360.Domain.Entities
{
    public class Donation : BaseEntity
    {
        public int ClinicId { get; set; }
        public string? FedexTransactionId { get; set; }
        public long? MasterTrackingNumber { get; set; }
        public long? TrackingNumber { get; set; }
        public bool UseOldLabel { get; set; }
        public string? LabelFileName { get; set; }
        public DonationStatus Status { get; set; }
        public int DonorId { get; set; }
        public long? ContainerId { get; set; }
        public double Amount { get; set; }
        public required ICollection<DonationProduct> Products { get; set; }
        public Vein360User Donor { get; set; }
        public Clinic Clinic { get; set; }


        #region GetProperties
        public List<string> ProductTypes
        {
            get
            {
                if (Products.Count != 0)
                {
                    return [.. this.Products.Select(x => x.Product?.Type.ToDescriptionString()).Distinct()];
                }

                return [];
            }
        }

        public bool IsNotProcessed()
        {
            return Status != DonationStatus.Processed && Status != DonationStatus.Paid;
        }

        public bool IsPaid => Status == DonationStatus.Paid;
        #endregion

    }
}

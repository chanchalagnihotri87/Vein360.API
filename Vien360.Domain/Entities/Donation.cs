using Vein360.Domain.Enums.Extensions;


namespace Vein360.Domain.Entities
{
    public class Donation : BaseEntity
    {
        public ContainerType ContainerType { get; set; }
        public int? DonationContainerId { get; set; }
        public int? FedexContainerId { get; set; }
        public string? FedexTransactionId { get; set; }
        public long? MasterTrackingNumber { get; set; }
        public long? TrackingNumber { get; set; }
        public string? LabelFileName { get; set; }
        public DonationStatus Status { get; set; }
        public double? Length { get; set; }
        public double? Width { get; set; }
        public double? Height { get; set; }
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
                    return [.. this.Products.Select(x => x.Product?.Type.ToDescriptionString()).Distinct()];
                }

                return [];
            }
        }


        public bool IsVein360ContainerDonation()
        {
            return ContainerType == ContainerType.Vein360Container;
        }

        public bool IsNotProcessed()
        {
            return Status != DonationStatus.Processed && Status != DonationStatus.Paid;
        }
    }
}

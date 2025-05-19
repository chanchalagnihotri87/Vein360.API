namespace Vein360.Domain.Entities
{
   public class DonationProduct
    {
        public int Id { get; set; }
        public int DonationId { get; set; }
        public int ProductId { get; set; }
        public int Units { get; set; }
        public int Accepted { get; set; }
        public int Rejected { get; set; }
        public Donation Donation { get; set; }
        public Product Product { get; set; }
    }
}

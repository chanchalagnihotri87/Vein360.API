namespace Vein360.Domain.Entities
{
    public class DonationProduct
    {
        public int Id { get; set; }
        public int DonationId { get; set; }
        public int ProductId { get; set; }
        public int Units { get; set; }
        public int Accepted { get; set; }

        public int RejectedClogged { get; set; }
        public int RejectedDamaged { get; set; }
        public int RejectedFunction { get; set; }
        public int RejectedKinked { get; set; }
        public int RejectedOther { get; set; }
        public Donation Donation { get; set; }
        public Product Product { get; set; }


        #region GetProperties

        public int Rejected
        {
            get
            {
                return RejectedClogged + RejectedDamaged + RejectedFunction + RejectedKinked + RejectedOther;
            }
        }
        #endregion
    }
}

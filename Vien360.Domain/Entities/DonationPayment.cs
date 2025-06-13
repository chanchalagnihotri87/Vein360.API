using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Domain.Entities
{
    public class DonationPayment : BaseEntity
    {
        public int DonationId { get; set; }
        public DateTime Date { get; set; }
        public int TransactionType { get; set; }
        public double Amount { get; set; }

        public Donation Donation { get; set; }
    }
}

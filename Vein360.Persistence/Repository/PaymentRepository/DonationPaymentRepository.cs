using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository.PaymentRepository;

namespace Vein360.Persistence.Repository.PaymentRepository
{
    public class DonationPaymentRepository : BaseRepository<DonationPayment>, IDonationPaymentRepository
    {
        public DonationPaymentRepository(Vein360Context context) : base(context)
        {
        }
    }
}

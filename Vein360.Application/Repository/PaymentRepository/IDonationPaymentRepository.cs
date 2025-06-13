using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Domain.Entities;

namespace Vein360.Application.Repository.PaymentRepository
{
    public interface IDonationPaymentRepository : IBaseRepository<DonationPayment>
    {
    }
}

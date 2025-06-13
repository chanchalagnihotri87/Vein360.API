using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.Donations.MakePayment
{
    public record DonationPaymentRequest(long ContainerId, DateTime Date, int TransactionType, double Amount) : IRequest
    {
    }
}

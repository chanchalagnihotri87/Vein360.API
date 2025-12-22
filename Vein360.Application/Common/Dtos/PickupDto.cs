using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Common.Dtos
{
   public class PickupDto
    {
        public string PickupTransactionId { get; set; }
        public string PickupConfirmationCode { get; set; }
        public DateTime PickupDateTime { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Common.Dtos
{
    public class ShipmentPickupDetailDto
    {
        public string TransactionId { get; set; }
        public string ConfirmationCode { get; set; }
        public IPickupTime PickupTime { get; set; }
    }
}

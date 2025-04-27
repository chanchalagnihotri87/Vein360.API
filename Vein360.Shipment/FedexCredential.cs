using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Shipment
{
   public class FedexCredential
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public long AccountNumber { get; set; }
    }
}

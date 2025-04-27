using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Dtos
{
    public class ShipmentDetailDto
    {
        public string TransactionId { get; set; }
        public string MasterTrackingNumber { get; set; }
        public string TrackingNumber { get; set; }
        public string LabelTrackingNumber { get; set; }
        public string EncodedLabel { get; set; }
    }
}

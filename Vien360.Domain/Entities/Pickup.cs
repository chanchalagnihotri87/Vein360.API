using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Domain.Entities
{
    public class Pickup : BaseEntity
    {
        public int Id { get; set; }
        public int ClinicId { get; set; }
        public string PickupTransactionId { get; set; }
        public string PickupConfirmationCode { get; set; }
        public DateTime PickupDateTime { get; set; }
        public Clinic Clinic { get; set; }
    }
}

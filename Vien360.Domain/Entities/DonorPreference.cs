using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Domain.Entities
{
    public class DonorPreference:BaseEntity
    {
        public int? DefaultClinicId { get; set; }
        public int DonorId { get; set; }
        public Vein360User Donor { get; set; }

        public Clinic Clinic { get; set; }
    }
}

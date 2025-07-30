using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Common.Dtos
{
    public class OrderDetailDto : OrderDto
    {
        public new ClinicDto Clinic { get; set; }
    }
}

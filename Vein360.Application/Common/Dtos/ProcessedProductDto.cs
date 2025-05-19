using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Common.Dtos
{
   public class ProcessedProductDto
    {
        public int Id { get; set; }
        public int Accepted { get; set; }
        public int Rejected { get; set; }
    }
}

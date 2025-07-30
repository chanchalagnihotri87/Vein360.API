using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Common.Dtos
{
    public class ClinicListItemDto
    {
        public int Id { get; set; }
        public required string ClinicName { get; set; }

        public string Name => ClinicName;
    }
}

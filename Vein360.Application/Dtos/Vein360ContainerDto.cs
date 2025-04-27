using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vien360.Domain.Entities;
using Vien360.Domain.Enums;

namespace Vein360.Application.Dtos
{
  public  class Vein360ContainerDto
    {
        public int ContainerTypeId { get; set; }
        public Vein360ContainerStatus Status { get; set; }
        public string ContainerCode { get; set; }
        public Vein360ContainerTypeDto ContainerType { get; set; }
    }
}

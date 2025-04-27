using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vien360.Domain.Enums
{
   public enum ContainerType
    {
        [Description("Vien360 Container")]
        Vien360Container = 1,
        [Description("Fedex Container")]
        FedexContainer = 2,
    }
}

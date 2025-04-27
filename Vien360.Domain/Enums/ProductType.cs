using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vien360.Domain.Enums
{
    public enum ProductType
    {
        [Description("Closure Fast Catheter")]
        ClosureFastCatheter = 1,
        [Description("Introducer Sheath")]
        IntroducerSheath = 2,
        [Description("IVUS Catheter")]
        IVUSCatheter = 3,
        [Description("Procedure Pack")]
        ProcedurePack = 4
    }
}

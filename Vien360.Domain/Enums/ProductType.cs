using System.ComponentModel;

namespace Vein360.Domain.Enums
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

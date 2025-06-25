using System.ComponentModel;

namespace Vein360.Domain.Enums
{
    public enum ProductType
    {
        [Description("Closure Fast")]
        ClosureFast = 1,
        [Description("IVUS Catheter")]
        IVUS = 2,
        [Description("Urology")]
        Urology = 3
    }
}

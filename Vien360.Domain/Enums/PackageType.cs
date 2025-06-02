using System.ComponentModel;

namespace Vein360.Domain.Enums
{
    public enum PackageType
    {
        [Description("Custom Package")]
        CustomPacking = 1,
        [Description("Vein360 Container")]
        Vein360Container = 2,
        [Description("Fedex Package")]
        FedexPacking = 3,
    }
}

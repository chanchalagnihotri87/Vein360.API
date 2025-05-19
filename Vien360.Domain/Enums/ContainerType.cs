using System.ComponentModel;

namespace Vein360.Domain.Enums
{
    public enum ContainerType
    {
        [Description("Vein360 Container")]
        Vein360Container = 1,
        [Description("Fedex Container")]
        FedexContainer = 2,
        [Description("Own Custom Packing")]
        OwnCustomPacking = 3
    }
}

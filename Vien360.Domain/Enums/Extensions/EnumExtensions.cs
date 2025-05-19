using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Domain.Enums.Extensions
{
    public static class EnumExtensions
    {
        public static string ToDescriptionString(this Enum value)
        {
            try
            {
                FieldInfo fi = value.GetType()?.GetField(value.ToString());

                DescriptionAttribute[] attributes =
                    (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute),
                    false);

                if (attributes != null &&
                    attributes.Length > 0)
                    return attributes[0].Description;
                else
                    return value?.ToString() ?? "Unset";
            }
            catch
            {
                return "Unset";
            }

        }

        public static int AsInt(this Enum value)
        {
            return (int)(object)value;
        }
    }
}

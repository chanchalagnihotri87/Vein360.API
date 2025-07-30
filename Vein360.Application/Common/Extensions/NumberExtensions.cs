using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Common.Extensions
{
    public static class NumberExtensions
    {
        public static bool IsNotNull(this long? number)
        {
            return number.HasValue;
        }
        public static bool IsNotNull(this double? number)
        {
            return number.HasValue;
        }


        public static double AsDouble(this decimal number)
        {
            return Convert.ToDouble(number);
        }

        public static decimal AsDecimal(this double number)
        {
            return Convert.ToDecimal(number);
        }
    }
}

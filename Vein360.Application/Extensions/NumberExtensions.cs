using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Extensions
{
    public static class NumberExtensions
    {
        public static bool IsNotNull(this long? number)
        {
            return number.HasValue;
        }
    }
}

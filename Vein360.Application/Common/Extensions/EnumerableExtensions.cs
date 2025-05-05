using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool HasItems(this IEnumerable<object> enumerable)
        {
            return enumerable != null && enumerable.Any();
        }
    }
}

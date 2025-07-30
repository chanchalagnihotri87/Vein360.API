using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Common.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsNotNull(this object obj)
        {
            return obj != null;
        }
    }
}

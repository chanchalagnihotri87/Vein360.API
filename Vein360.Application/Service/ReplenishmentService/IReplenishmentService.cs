using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Service.ReplenishmentService
{
   public interface IReplenishmentService
    {
        int CreateReplenishmentOrder(int containerTypeId, int units, int donorId);//Todo: Replace donorId with clinicId when implemented
    }
}

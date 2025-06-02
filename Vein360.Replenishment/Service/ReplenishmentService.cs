using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Service.ReplenishmentService;

namespace Vein360.Replenishment.Service
{
    public class ReplenishmentService : IReplenishmentService
    {
        public int CreateReplenishmentOrder(int containerTypeId, int units, int donorId)
        {
            //TODO: Implement the logic to create a replenishment order
          
            return  new Random().Next(1, 1000); 
        }
    }
}

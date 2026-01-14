using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository.PickupRepository;

namespace Vein360.Persistence.Repository.PickupRepository
{
    public class PickupRepository : BaseRepository<Pickup>, IPickupRepository
    {
        public PickupRepository(Vein360Context context) : base(context)
        {
        }
    }
}

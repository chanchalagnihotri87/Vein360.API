using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository.DonorPreferenceRepository;

namespace Vein360.Persistence.Repository.DonorPreferenceRepository
{
    public class DonorPreferenceRepository : BaseRepository<DonorPreference>, IDonorPreferenceRepository
    {
        public DonorPreferenceRepository(Vein360Context context) : base(context)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository.UserProductRateRepository;

namespace Vein360.Persistence.Repository.UserProductRateRepository
{
    public class UserProductRateRepository : BaseRepository<UserProductRate>, IUserProductRateRepository
    {
        public UserProductRateRepository(Vein360Context context) : base(context)
        {
        }
    }
}

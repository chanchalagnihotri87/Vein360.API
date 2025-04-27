using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository.UserRepository;
using Vien360.Domain.Entities;

namespace Vein360.Persistence.Repository.UserRepository
{
    public class UserRepository : BaseRepository<Vein360User>, IUserRepository
    {
        public UserRepository(Vein360Context context) : base(context)
        {
        }
    }
}

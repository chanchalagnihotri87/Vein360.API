using Vein360.Application.Repository.UserRepository;

namespace Vein360.Persistence.Repository.UserRepository
{
    public class UserRepository : BaseRepository<Vein360User>, IUserRepository
    {
        public UserRepository(Vein360Context context) : base(context)
        {
        }
    }
}

using Vein360.Application.Repository.ContainerRepository;

namespace Vein360.Persistence.Repository.ContainerRepository
{
    public class ContainerRepository : BaseRepository<Vein360Container>, IContainerRepository
    {
        public ContainerRepository(Vein360Context context) : base(context)
        {
        }
    }
}

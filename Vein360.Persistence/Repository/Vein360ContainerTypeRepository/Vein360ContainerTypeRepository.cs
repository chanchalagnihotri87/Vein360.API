using Vein360.Application.Repository.Vein360ContainerTypeRepository;

namespace Vein360.Persistence.Repository.Vein360ContainerTypeRepository
{
    public class Vein360ContainerTypeRepository(Vein360Context context) : BaseRepository<Vein360ContainerType>(context), IVein360ContainerTypeRepository
    {
    }
}

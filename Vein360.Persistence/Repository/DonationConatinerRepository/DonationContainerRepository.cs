using Vein360.Application.Repository.DonationContainerRepository;

namespace Vein360.Persistence.Repository.DonationConatinerRepository
{
    public class DonationContainerRepository(Vein360Context context) : BaseRepository<DonationContainer>(context), IDonationContainerRepository
    {
    }
}

using Vein360.Application.Repository.DonationsRepository;

namespace Vein360.Persistence.Repository.DonationRepository
{
    public class DonationRepository : BaseRepository<Donation>, IDonationRepository
    {
        public DonationRepository(Vein360Context context) : base(context)
        {
        }
    }
}

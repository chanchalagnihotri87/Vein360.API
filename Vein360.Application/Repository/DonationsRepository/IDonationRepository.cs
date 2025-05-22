using Vein360.Domain.Entities;

namespace Vein360.Application.Repository.DonationsRepository
{
    public interface IDonationRepository : IBaseRepository<Donation>
    {
        DonationStatisticDto GetStatistic(int donorId);
    }
}

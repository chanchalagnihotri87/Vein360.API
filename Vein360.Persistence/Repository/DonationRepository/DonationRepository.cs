using Microsoft.EntityFrameworkCore;
using Vein360.Application.Common.Dtos;
using Vein360.Application.Repository.DonationsRepository;

namespace Vein360.Persistence.Repository.DonationRepository
{
    public class DonationRepository : BaseRepository<Donation>, IDonationRepository
    {
        public DonationRepository(Vein360Context context) : base(context)
        {
        }

        public DonationStatisticDto GetStatistic(int donorId)
        {
            var donatedProductsCount = GetAllAsQueryable().Include(x => x.Products).Where(x => x.DonorId == donorId).SelectMany(x => x.Products).Sum(x => x.Units);

            var totalEarning = GetAllAsQueryable().Where(x => x.DonorId == donorId).Sum(x => x.Amount);

            return new DonationStatisticDto
            {
                TotalProducts = donatedProductsCount,
                TotalEarning = totalEarning
            };
        }
    }
}

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
            var donationProducts = GetAllAsQueryable().Include(x => x.Products).Where(x => x.DonorId == donorId).SelectMany(x => x.Products).ToHashSet();

            return new DonationStatisticDto
            {
                TotalProducts = donationProducts.Sum(x => x.Units),
                AcceptedProducts = donationProducts.Sum(x => x.Accepted),
                RejectedProducts = donationProducts.Sum(x => x.Rejected)
            };
        }
    }
}

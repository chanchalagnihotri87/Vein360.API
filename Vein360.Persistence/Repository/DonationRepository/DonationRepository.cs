using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository;
using Vein360.Application.Repository.DonationsRepository;
using Vien360.Domain.Entities;

namespace Vein360.Persistence.Repository.DonationRepository
{
    public class DonationRepository : BaseRepository<Donation>, IDonationRepository
    {
        public DonationRepository(Vein360Context context) : base(context)
        {
        }

        public new async Task<ICollection<Donation>> GetAllAsync(params Expression<Func<IQueryable<Donation>, IIncludableQueryable<Donation, object>>>[] includes)
        {
            return (await base.GetAllAsync(includes)).OrderByDescending(x => x.Id).ToHashSet();
        }


    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vein360.Application.Common.Dtos;
using Vein360.Application.Repository.ClinicRepository;

namespace Vein360.Persistence.Repository.ClinicRepository
{
    public class ClinicRepository : BaseRepository<Clinic>, IClinicRepository
    {
        public ClinicRepository(Vein360Context context) : base(context)
        {
        }

        public async Task<ICollection<ListItemDto>> GetUserClinicsList(int userId, CancellationToken cancellationToken)
        {
            return await GetAllAsQueryable().Where(x => x.UserId == userId).Select(x => new ListItemDto { Id = x.Id, Name = x.ClinicCode }).ToHashSetAsync(cancellationToken);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Domain.Entities;

namespace Vein360.Application.Repository.ClinicRepository
{
    public interface IClinicRepository : IBaseRepository<Clinic>
    {
        Task<ICollection<ListItemDto>> GetUserClinicsList(int userId, CancellationToken cancellationToken);
    }
}

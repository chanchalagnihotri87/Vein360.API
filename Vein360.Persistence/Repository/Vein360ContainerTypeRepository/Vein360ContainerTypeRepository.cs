using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository.Vein360ContainerTypeRepository;
using Vien360.Domain.Entities;

namespace Vein360.Persistence.Repository.Vein360ContainerTypeRepository
{
    public class Vein360ContainerTypeRepository : BaseRepository<Vein360ContainerType>, IVein360ContainerTypeRepository
    {
        public Vein360ContainerTypeRepository(Vein360Context context) : base(context)
        {
        }
    }
}

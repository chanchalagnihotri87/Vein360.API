using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository.DonationContainerRepository;
using Vien360.Domain.Entities;

namespace Vein360.Persistence.Repository.DonationConatinerRepository
{
    public class DonationContainerRepository(Vein360Context context) : BaseRepository<DonationContainer>(context), IDonationContainerRepository
    {
    }
}

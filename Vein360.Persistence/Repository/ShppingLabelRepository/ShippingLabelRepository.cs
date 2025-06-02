using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Common.Dtos;
using Vein360.Application.Repository.ShippingLabelRepository;

namespace Vein360.Persistence.Repository.ShippingLabelRepository
{
    public class ShippingLabelRepository : BaseRepository<ShippingLabel>, IShippingLabelRepository
    {
        public ShippingLabelRepository(Vein360Context context) : base(context)
        {
        }

        public async Task<ICollection<long>> GetAvailableLabelsList(int clinicId, CancellationToken cancellationToken)
        {
            return await GetAllAsQueryable().Where(x => x.ClinicId == clinicId && !x.Used).Select(x => x.TrackingNumber).ToHashSetAsync(cancellationToken);
        }

        public async Task<ShippingLabel> GetLabelByTrackingNumber(long trackingNumber, CancellationToken cancellationToken)
        {
            return await GetAsync(x => x.TrackingNumber == trackingNumber);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Domain.Entities;

namespace Vein360.Application.Repository.ShippingLabelRepository
{
    public interface IShippingLabelRepository : IBaseRepository<ShippingLabel>
    {
        Task<ICollection<long>> GetAvailableLabelsList(int clinicId, CancellationToken cancellationToken);
        Task<ShippingLabel> GetLabelByTrackingNumber(long trackingNumber, CancellationToken cancellationToken);
    }
}

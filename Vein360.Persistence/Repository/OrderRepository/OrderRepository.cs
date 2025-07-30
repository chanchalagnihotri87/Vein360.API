using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository;
using Vein360.Application.Repository.OrderRepository;

namespace Vein360.Persistence.Repository.OrderRepository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(Vein360Context context) : base(context)
        {
        }
    }
}

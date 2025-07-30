using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository.DonationsRepository;
using Vein360.Application.Repository.OrderRepository;

namespace Vein360.Application.Features.Orders.GetAllOrders
{
    public class GetAllOrdersRequestHandler : IRequestHandler<GetAllOrdersRequest, List<OrderDto>>
    {
        private readonly IOrderRepository _orderRepo;

        public GetAllOrdersRequestHandler(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public async Task<List<OrderDto>> Handle(GetAllOrdersRequest request, CancellationToken cancellationToken)
        {
            var donations = await _orderRepo.GetAllAsNoTrackingAsync(order => order.Include(x => x.Product), 
                                                                     order => order.Include(x => x.Clinic));

            return donations.Adapt<List<OrderDto>>();
        }
    }
}

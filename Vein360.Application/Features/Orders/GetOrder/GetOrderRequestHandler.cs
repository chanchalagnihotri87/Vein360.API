using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository.OrderRepository;

namespace Vein360.Application.Features.Orders.GetOrder
{
    public class GetOrderRequestHandler : IRequestHandler<GetOrderRequest, OrderDetailDto>
    {
        private readonly IOrderRepository _orderRepo;

        public GetOrderRequestHandler(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public async Task<OrderDetailDto> Handle(GetOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderRepo.GetAsync(x => x.Id == request.OrderId, cancellationToken,
                                                order => order.Include(x => x.Product),
                                                order => order.Include(x => x.Clinic));

            return order.Adapt<OrderDetailDto>();
        }
    }
}

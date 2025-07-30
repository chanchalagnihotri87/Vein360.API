using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository.OrderRepository;
using Vein360.Application.Service.AuthenticationService;

namespace Vein360.Application.Features.Orders.GetMyOrders
{
    public class GetMyOrdersRequestHandler : IRequestHandler<GetMyOrdersRequest, List<OrderDto>>
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IAuthInfoService _authInfoService;

        public GetMyOrdersRequestHandler(IOrderRepository orderRepo, IAuthInfoService authInfoService)
        {
            _orderRepo = orderRepo;
            _authInfoService = authInfoService;
        }


        public async Task<List<OrderDto>> Handle(GetMyOrdersRequest request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepo.GetManyAsNoTrackingAsync(x => x.UserId == _authInfoService.UserId,
                                                                        cancellationToken,
                                                                        order => order.Include(x => x.Product),
                                                                        order => order.Include(x => x.Clinic));

            return orders.OrderByDescending(x => x.CreatedDate).Adapt<List<OrderDto>>();
        }
    }
}

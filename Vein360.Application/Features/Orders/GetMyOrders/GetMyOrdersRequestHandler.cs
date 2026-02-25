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
    public class GetMyOrdersRequestHandler : IRequestHandler<GetMyOrdersRequest, PagedResponse<OrderDto>>
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IAuthInfoService _authInfoService;

        public GetMyOrdersRequestHandler(IOrderRepository orderRepo, IAuthInfoService authInfoService)
        {
            _orderRepo = orderRepo;
            _authInfoService = authInfoService;
        }


        public async Task<PagedResponse<OrderDto>> Handle(GetMyOrdersRequest request, CancellationToken cancellationToken)
        {
            var pagedResponse = new PagedResponse<OrderDto>();

            var query = _orderRepo.GetManyAsQueryableNoTracking(x => x.UserId == _authInfoService.UserId);

            pagedResponse.CalculateTotalPages(await query.CountAsync());

            pagedResponse.CalculateSkipCount(request.Page);

            pagedResponse.Items = query.OrderByDescending(x => x.Id).Skip(pagedResponse.Skip).Take(pagedResponse.PageSize).Select(x => new OrderDto
            {
                Id = x.Id,
                Status = x.Status,
                Quantity = x.Quantity,
                CreatedDate = x.CreatedDate,
                Clinic = new ClinicDto { Id = x.ClinicId, ClinicName = x.Clinic.ClinicName },
                Product = new ProductDto
                {
                    Id = x.Product.Id,
                    Name = x.Product.Name,
                    Type = x.Product.Type,
                    Image = x.Product.Image,
                    Price = x.Product.Price
                }
            }).ToHashSet();

            return pagedResponse;
        }
    }
}

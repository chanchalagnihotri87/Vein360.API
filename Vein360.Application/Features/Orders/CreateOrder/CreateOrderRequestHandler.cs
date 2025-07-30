using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository;
using Vein360.Application.Repository.OrderRepository;
using Vein360.Application.Repository.ProductRepository;
using Vein360.Application.Service.AuthenticationService;
using Vein360.Domain.Entities;

namespace Vein360.Application.Features.Orders.CreateOrder
{
    public class CreateOrderRequestHandler : IRequestHandler<CreateOrderRequest>
    {
        private readonly IAuthInfoService _authInfo;
        private readonly IOrderRepository _orderRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepo;

        public CreateOrderRequestHandler(
            IAuthInfoService authInfo,
            IOrderRepository orderRepo,
            IUnitOfWork unitOfWork,
            IProductRepository productRepo)
        {
            _authInfo = authInfo;
            _orderRepo = orderRepo;
            _unitOfWork = unitOfWork;
            _productRepo = productRepo;
        }

        public async Task Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepo.GetByIdAsync(request.ProductId);

            var order = new Order
            {
                ProductId = request.ProductId,
                Price = product.Price,
                ClinicId = request.ClinicId,
                UserId = _authInfo.UserId,
                Status = OrderStatus.Ordered
            };

            _orderRepo.Create(order);

            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}

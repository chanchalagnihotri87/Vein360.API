using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository;
using Vein360.Application.Repository.OrderRepository;
using Vein360.Application.Repository.ProductRepository;
using Vein360.Application.Repository.UserProductRateRepository;
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
        private readonly IUserProductRateRepository _userProductRateRepo;



        public CreateOrderRequestHandler(
            IAuthInfoService authInfo,
            IOrderRepository orderRepo,
            IUnitOfWork unitOfWork,
            IProductRepository productRepo,
            IUserProductRateRepository userProductRateRepo)
        {
            _authInfo = authInfo;
            _orderRepo = orderRepo;
            _unitOfWork = unitOfWork;
            _productRepo = productRepo;
            _userProductRateRepo = userProductRateRepo;
        }

        public async Task Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepo.GetByIdAsync(request.ProductId);
            var userProductRate = await _userProductRateRepo.GetAsync(x => x.UserId == _authInfo.UserId && x.ProductId == request.ProductId);

            var order = new Order
            {
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                Price = product.Price,
                ClinicId = request.ClinicId,
                UserId = _authInfo.UserId,
                Status = OrderStatus.Ordered
            };

            if (userProductRate.IsNotNull() && userProductRate.Price.IsNotNull())
            {
                order.Price = userProductRate!.Price!.Value.AsDecimal();
            }

            _orderRepo.Create(order);

            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}

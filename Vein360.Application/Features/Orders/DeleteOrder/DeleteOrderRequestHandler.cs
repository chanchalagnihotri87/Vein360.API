using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository;
using Vein360.Application.Repository.OrderRepository;

namespace Vein360.Application.Features.Orders.DeleteOrder
{
    public class DeleteOrderRequestHandler : IRequestHandler<DeleteOrderRequest>
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOrderRequestHandler(IOrderRepository orderRepo, IUnitOfWork unitOfWork)
        {
            _orderRepo = orderRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteOrderRequest request, CancellationToken cancellationToken)
        {
            await _orderRepo.DeleteByIdAsync(request.Id);

            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}

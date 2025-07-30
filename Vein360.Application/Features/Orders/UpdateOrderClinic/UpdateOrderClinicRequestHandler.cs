using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository;
using Vein360.Application.Repository.OrderRepository;

namespace Vein360.Application.Features.Orders.UpdateOrderClinic
{
    public class UpdateOrderClinicRequestHandler : IRequestHandler<UpdateOrderClinicRequest, OrderDto>
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOrderClinicRequestHandler(IOrderRepository orderRepo, IUnitOfWork unitOfWork)
        {
            _orderRepo = orderRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<OrderDto> Handle(UpdateOrderClinicRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderRepo.GetByIdAsync(request.OrderId);
         
            order.ClinicId = request.ClinicId;

            _orderRepo.Update(order);
            await _unitOfWork.SaveAsync(cancellationToken);


            var updatedOrder = await _orderRepo.GetAsNoTrackingAsync(x => x.Id == request.OrderId,
                                                                          cancellationToken,
                                                                          order => order.Include(x => x.Product),
                                                                                   order => order.Include(x => x.Clinic));

            return updatedOrder.Adapt<OrderDto>();
        }
    }
}

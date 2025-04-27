using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository;
using Vein360.Application.Repository.DonationContainerRepository;
using Vien360.Domain.Entities;
using Vien360.Domain.Enums;

namespace Vein360.Application.Features.DonationContainers.RequestForContainer
{
    public class RequestForContainerRequestHandler(IUnitOfWork unitOfWork, IDonationContainerRepository containerRepo) : IRequestHandler<RequestForContainerRequest>
    {
        private const int USER_ID = 1;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IDonationContainerRepository _containerRepo = containerRepo;

        public async Task Handle(RequestForContainerRequest request, CancellationToken cancellationToken)
        {
            var container = new DonationContainer
            {
                ContainerTypeId = request.ContainerTypeId,
                Status = DonationContainerStatus.Requested,
                DonorId = USER_ID
            };

            _containerRepo.Create(container);

            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}

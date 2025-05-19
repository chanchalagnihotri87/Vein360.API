using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository;
using Vein360.Application.Repository.ContainerRepository;

namespace Vein360.Application.Features.Vein360Containers.DeleteContainer
{
    public class DeleteContainerRequestHandler:IRequestHandler<DeleteContainerRequest>
    {
        private readonly IContainerRepository _containerRepo;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteContainerRequestHandler(
            IContainerRepository containerRepo,
            IUnitOfWork unitOfWork)
        {
            _containerRepo = containerRepo;
            _unitOfWork = unitOfWork;
        }


        public async Task Handle(DeleteContainerRequest request, CancellationToken cancellationToken)
        {
            var container = await _containerRepo.GetByIdAsync(request.Id);
            if (container == null)
            {
                throw new Exception("Container not found");
            }

            _containerRepo.Delete(container);
            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}

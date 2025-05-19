using Microsoft.EntityFrameworkCore;
using Vein360.Application.Repository;
using Vein360.Application.Repository.ContainerRepository;

namespace Vein360.Application.Features.Vein360Containers.UpdateContainer
{
    public class UpdateContainerRequestHandler : IRequestHandler<UpdateContainerRequest, ContainerDto>
    {
        private readonly IContainerRepository _containerRepo;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateContainerRequestHandler(
             IContainerRepository containerRepo,
             IUnitOfWork unitOfWork)
        {
            _containerRepo = containerRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<ContainerDto> Handle(UpdateContainerRequest request, CancellationToken cancellationToken)
        {
            var container = await _containerRepo.GetByIdAsync(request.Id);

            if (container == null)
            {
                throw new Exception("Container not found");
            }

            container.ContainerTypeId = request.ContainerTypeId;
            container.ContainerCode = request.ContainerCode;
            container.Status = request.Status;


            _containerRepo.Update(container);

            await _unitOfWork.SaveAsync(cancellationToken);

            container = await _containerRepo.GetAsync(x => x.Id == container.Id, cancellationToken, x => x.Include(x => x.ContainerType));

            return container.Adapt<ContainerDto>();
        }
    }

}

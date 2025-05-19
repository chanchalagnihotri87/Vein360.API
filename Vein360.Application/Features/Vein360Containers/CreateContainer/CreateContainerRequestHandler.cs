using Microsoft.EntityFrameworkCore;
using Vein360.Application.Repository;
using Vein360.Application.Repository.ContainerRepository;
using Vein360.Domain.Entities;

namespace Vein360.Application.Features.Vein360Containers.CreateContainer
{
    public class CreateContainerRequestHandler : IRequestHandler<CreateContainerRequest, ContainerDto>
    {
        private readonly IContainerRepository _containerRepo;
        private readonly IUnitOfWork _unitOfWork;

        public CreateContainerRequestHandler(
             IContainerRepository containerRepo,
             IUnitOfWork unitOfWork)
        {
            _containerRepo = containerRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<ContainerDto> Handle(CreateContainerRequest request, CancellationToken cancellationToken)
        {
            var container = new Vein360Container
            {
                ContainerTypeId = request.ContainerTypeId,
                ContainerCode = request.ContainerCode,
                Status= Vein360ContainerStatus.Available
            };

            _containerRepo.Create(container);

            await _unitOfWork.SaveAsync(cancellationToken);

            container = await _containerRepo.GetAsync(x => x.Id == container.Id, cancellationToken, x => x.Include(x => x.ContainerType));

            return container.Adapt<ContainerDto>();
        }
    }

}

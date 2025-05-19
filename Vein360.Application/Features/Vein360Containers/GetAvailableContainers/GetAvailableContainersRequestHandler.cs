using Vein360.Application.Repository.ContainerRepository;

namespace Vein360.Application.Features.Vein360Containers.GetAvailableContainers
{
    public class GetAvailableContainersRequestHandler : IRequestHandler<GetAvailableContainersRequest, IEnumerable<ContainerDto>>
    {
        private readonly IContainerRepository _containerRepo;

        public GetAvailableContainersRequestHandler(IContainerRepository containerRepo)
        {
            _containerRepo = containerRepo;
        }


        public async Task<IEnumerable<ContainerDto>> Handle(GetAvailableContainersRequest request, CancellationToken cancellationToken)
        {
            var containers = await _containerRepo.GetManyAsync(x => x.ContainerTypeId == request.ContainerTypeId && 
                                                                    x.Status == Vein360ContainerStatus.Available);

            return containers.Adapt<IEnumerable<ContainerDto>>();
        }
    }
}

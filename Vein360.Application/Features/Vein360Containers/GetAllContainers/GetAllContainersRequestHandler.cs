using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository.ContainerRepository;

namespace Vein360.Application.Features.Vein360Containers.GetAllContainers
{
    public class GetAllContainersRequestHandler : IRequestHandler<GetAllContainersRequest, List<ContainerDto>>
    {
        private readonly IContainerRepository _containerRepo;
        public GetAllContainersRequestHandler(IContainerRepository containerRepo)
        {
            _containerRepo = containerRepo;
        }
        public async Task<List<ContainerDto>> Handle(GetAllContainersRequest request, CancellationToken cancellationToken)
        {
            var containers = await _containerRepo.GetAllAsync(cancellationToken,
                cnt => cnt.Include(x => x.ContainerType));

            return containers.OrderByDescending(x => x.Id).Adapt<List<ContainerDto>>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Common.Dtos;
using Vein360.Application.Repository.DonationContainerRepository;
using Vein360.Application.Repository.Vein360ContainerTypeRepository;

namespace Vein360.Application.Features.ContainerTypes.GetAllContainerTypes
{
    public class GetAllContainerTypesRequestHandler(IVein360ContainerTypeRepository containerTypeRepo) : IRequestHandler<GetAllContainerTypesRequest, List<ContainerTypeDto>>
    {
        private readonly IVein360ContainerTypeRepository _containerTypeRepo = containerTypeRepo;

        public async Task<List<ContainerTypeDto>> Handle(GetAllContainerTypesRequest request, CancellationToken cancellationToken)
        {
            var containers = await _containerTypeRepo.GetAllAsync(cancellationToken);

            return containers.Adapt<List<ContainerTypeDto>>();
        }
    }
}

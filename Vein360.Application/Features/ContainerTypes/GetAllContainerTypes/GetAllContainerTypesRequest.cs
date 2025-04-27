using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Dtos;

namespace Vein360.Application.Features.ContainerTypes.GetAllContainerTypes
{
    public record GetAllContainerTypesRequest : IRequest<List<ContainerTypeDto>>
    {
    }
}

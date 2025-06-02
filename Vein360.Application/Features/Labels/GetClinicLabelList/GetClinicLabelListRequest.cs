using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.Labels.GetClinicLabelList
{
    public record GetClinicLabelListRequest(int ClinicId) : IRequest<ICollection<long>>
    {
    }
}

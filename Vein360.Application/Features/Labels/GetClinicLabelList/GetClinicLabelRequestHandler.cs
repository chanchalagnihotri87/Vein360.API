using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository.ClinicRepository;
using Vein360.Application.Repository.ShippingLabelRepository;

namespace Vein360.Application.Features.Labels.GetClinicLabelList
{
    public class GetClinicLabelRequestHandler : IRequestHandler<GetClinicLabelListRequest, ICollection<long>>
    {
        private readonly IShippingLabelRepository _labelRepo;

        public GetClinicLabelRequestHandler(IShippingLabelRepository labelRepo)
        {
            _labelRepo = labelRepo;
        }

        public async Task<ICollection<long>> Handle(GetClinicLabelListRequest request, CancellationToken cancellationToken)
        {
            return await _labelRepo.GetAvailableLabelsList(request.ClinicId, cancellationToken);
        }
    }
}

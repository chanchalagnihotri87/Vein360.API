using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository.DonorPreferenceRepository;

namespace Vein360.Application.Features.DonorPreferences.GetPreferenceByDonorId
{
    public class GetPreferenceByDonorIdRequestHandler : IRequestHandler<GetPreferenceByDonorIdRequest, DonorPreferenceDto>
    {
        private readonly IDonorPreferenceRepository _preferenceRepo;

        public GetPreferenceByDonorIdRequestHandler(IDonorPreferenceRepository preferenceRepo)
        {
            _preferenceRepo = preferenceRepo;
        }

        public async Task<DonorPreferenceDto> Handle(GetPreferenceByDonorIdRequest request, CancellationToken cancellationToken)
        {
            var preference = await _preferenceRepo.GetAsync(x => x.DonorId == request.DonorId);

            return preference.Adapt<DonorPreferenceDto>();
        }
    }
}

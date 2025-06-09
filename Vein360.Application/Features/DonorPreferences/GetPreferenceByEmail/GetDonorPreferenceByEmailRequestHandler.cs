using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository.DonorPreferenceRepository;

namespace Vein360.Application.Features.DonorPreferences.GetPreferenceByEmail
{
    public class GetDonorPreferenceRequestHandler : IRequestHandler<GetDonorPreferenceByEmailRequest, DonorPreferenceDto>
    {
        private readonly IDonorPreferenceRepository _donorPreferenceRepo;

        public GetDonorPreferenceRequestHandler(IDonorPreferenceRepository donorPreferenceRepo)
        {
            _donorPreferenceRepo = donorPreferenceRepo;
        }

        public async Task<DonorPreferenceDto> Handle(GetDonorPreferenceByEmailRequest request, CancellationToken cancellationToken)
        {
            var donorPreference = await _donorPreferenceRepo.GetAsync(x => x.Donor.Email.ToLower() == request.email.ToLower());

            return donorPreference.Adapt<DonorPreferenceDto>();
        }
    }
}

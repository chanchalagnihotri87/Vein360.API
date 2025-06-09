using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository.ClinicRepository;

namespace Vein360.Application.Features.Clinics.GetClinic
{
    public class GetClinicRequestHandler : IRequestHandler<GetClinicRequest, ClinicDto>
    {
        private readonly IClinicRepository _clinicRepo;

        public GetClinicRequestHandler(IClinicRepository clinicRepo)
        {
            _clinicRepo = clinicRepo;
        }

        public async Task<ClinicDto> Handle(GetClinicRequest request, CancellationToken cancellationToken)
        {
            var clinic = await _clinicRepo.GetByIdAsync(request.Id, cancellationToken);

            return clinic.Adapt<ClinicDto>();
        }
    }
}

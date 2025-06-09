using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository.ClinicRepository;

namespace Vein360.Application.Features.Clinics.GetClinics
{
    public class GetClinicsRequestHandler : IRequestHandler<GetClinicsRequest, List<ClinicDto>>
    {
        private readonly IClinicRepository _clinicRepo;

        public GetClinicsRequestHandler(IClinicRepository clinicRepo)
        {
            this._clinicRepo= clinicRepo;
        }

        public async Task<List<ClinicDto>> Handle(GetClinicsRequest request, CancellationToken cancellationToken)
        {
            var clinics = await this._clinicRepo.GetManyAsync(x => x.UserId == request.UserId, cancellationToken);

            return clinics.Adapt<List<ClinicDto>>();
        }
    }
}

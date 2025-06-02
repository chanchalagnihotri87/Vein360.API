using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository.ClinicRepository;
using Vein360.Application.Service.AuthenticationService;

namespace Vein360.Application.Features.Clinics.GetClinics
{
    public class GetClinicListRequestHandler : IRequestHandler<GetClinicListRequest, ICollection<ListItemDto>>
    {
        private readonly IAuthInfoService _authInfo;
        private readonly IClinicRepository _clinicRepo;

        public GetClinicListRequestHandler(IAuthInfoService authInfo, IClinicRepository clinicRepo)
        {
            _authInfo = authInfo;
            _clinicRepo = clinicRepo;
        }

        public Task<ICollection<ListItemDto>> Handle(GetClinicListRequest request, CancellationToken cancellationToken)
        {
            return _clinicRepo.GetUserClinicsList(_authInfo.UserId, cancellationToken);
        }

    }
}

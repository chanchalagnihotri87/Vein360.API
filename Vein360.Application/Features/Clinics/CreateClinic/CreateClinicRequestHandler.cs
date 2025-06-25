using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository;
using Vein360.Application.Repository.ClinicRepository;
using Vein360.Application.Service.AuthenticationService;
using Vein360.Domain.Entities;

namespace Vein360.Application.Features.Clinics.CreateClinic
{
    public class CreateClinicRequestHandler : IRequestHandler<CreateClinicRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthInfoService _authInfo;
        private readonly IClinicRepository _clinicRepo;

        public CreateClinicRequestHandler(IAuthInfoService authInfo,
                                          IUnitOfWork unitOfWork,
                                          IClinicRepository clinicRepo)
        {
            _authInfo = authInfo;
            _clinicRepo = clinicRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateClinicRequest request, CancellationToken cancellationToken)
        {
            var clinic = new Clinic
            {
                ClinicName = request.ClinicName,
                PrimaryContactName = request.ContactName,
                PrimaryContactEmail = request.ContactEmail,
                PrimaryContactPhone = request.ContactPhone,
                AddressLine1 = request.AddressLine1,
                AddressLine2 = request.AddressLine2,
                City = request.City,
                State = request.State,
                Country = request.Country,
                PostalCode = request.PostalCode,
                UserId = request.UserId
            };

            _clinicRepo.Create(clinic);

            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}

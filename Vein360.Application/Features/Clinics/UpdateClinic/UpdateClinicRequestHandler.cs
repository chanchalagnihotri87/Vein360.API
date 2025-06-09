using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository;
using Vein360.Application.Repository.ClinicRepository;

namespace Vein360.Application.Features.Clinics.UpdateClinic
{
    public class UpdateClinicRequestHandler : IRequestHandler<UpdateClinicRequest>
    {
        private readonly IClinicRepository _clinicRepo;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateClinicRequestHandler(
            IUnitOfWork unitOfWork,
            IClinicRepository clinicRepo)
        {
            _unitOfWork = unitOfWork;
            _clinicRepo = clinicRepo;
        }

        public async Task Handle(UpdateClinicRequest request, CancellationToken cancellationToken)
        {
            var clinic = await _clinicRepo.GetByIdAsync(request.Id);

            if (clinic != null)
            {
                clinic.ClinicName = request.ClinicName;
                clinic.ClinicCode = request.ClinicCode;
                clinic.Phone = request.Phone;
                clinic.StreetLine = request.StreetLine;
                clinic.City = request.City;
                clinic.State = request.State;
                clinic.Country = request.Country;
                clinic.PostalCode = request.PostalCode;

                _clinicRepo.Update(clinic);

                await _unitOfWork.SaveAsync(cancellationToken);

            }
        }
    }
}

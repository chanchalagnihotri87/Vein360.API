using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository;
using Vein360.Application.Repository.ClinicRepository;

namespace Vein360.Application.Features.Clinics.DeleteClinic
{
    public class DeleteClinicRequestHandler : IRequestHandler<DeleteClinicRequest>
    {
        private readonly IClinicRepository _clinicRepo;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteClinicRequestHandler(IClinicRepository clinicRepo, IUnitOfWork unitOfWork)
        {
            _clinicRepo = clinicRepo;
            _unitOfWork = unitOfWork;
        }



        public async Task Handle(DeleteClinicRequest request, CancellationToken cancellationToken)
        {
            var clinic = await _clinicRepo.GetByIdAsync(request.Id);

            if (clinic != null)
            {
                _clinicRepo.Delete(clinic);

                await _unitOfWork.SaveAsync(cancellationToken);
            }
        }
    }
}

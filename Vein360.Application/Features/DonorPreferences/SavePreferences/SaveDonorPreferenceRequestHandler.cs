using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository;
using Vein360.Application.Repository.DonorPreferenceRepository;
using Vein360.Domain.Entities;

namespace Vein360.Application.Features.DonorPreferences.SavePreferences
{
    public class SaveDonorPreferenceRequestHandler : IRequestHandler<SaveDonorPreferenceRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDonorPreferenceRepository _donorPreferenceRepo;

        public SaveDonorPreferenceRequestHandler(
            IUnitOfWork unitOfWork,
            IDonorPreferenceRepository donorPreferenceRepo)
        {
            _unitOfWork = unitOfWork;
            _donorPreferenceRepo = donorPreferenceRepo;
        }

        public async Task Handle(SaveDonorPreferenceRequest request, CancellationToken cancellationToken)
        {
            var preference = await _donorPreferenceRepo.GetAsync(x => x.DonorId == request.DonorId, cancellationToken);

            if (preference != null)
            {
                preference.DefaultClinicId = request.defaultClinicId;

                _donorPreferenceRepo.Update(preference);

                await _unitOfWork.SaveAsync(cancellationToken);

                return;
            }

            preference = new DonorPreference
            {
                DonorId = request.DonorId,
                DefaultClinicId = request.defaultClinicId
            };

            _donorPreferenceRepo.Create(preference);

            await _unitOfWork.SaveAsync(cancellationToken);

        }
    }
}

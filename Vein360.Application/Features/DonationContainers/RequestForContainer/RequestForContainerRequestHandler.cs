using Vein360.Application.Repository;
using Vein360.Application.Repository.DonationContainerRepository;
using Vein360.Application.Service.AuthenticationService;
using Vein360.Domain.Entities;

namespace Vein360.Application.Features.DonationContainers.RequestForContainer
{
    public class RequestForContainerRequestHandler : IRequestHandler<RequestForContainerRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthInfoService _authInfo;
        private readonly IDonationContainerRepository _containerRepo;


        public RequestForContainerRequestHandler(IUnitOfWork unitOfWork, IAuthInfoService authInfo, IDonationContainerRepository containerRepo)
        {
            _authInfo = authInfo;
            _unitOfWork = unitOfWork;
            _containerRepo = containerRepo;
        }

        public async Task Handle(RequestForContainerRequest request, CancellationToken cancellationToken)
        {
            var container = new DonationContainer
            {
                DonorId = _authInfo.UserId,
                ContainerTypeId = request.ContainerTypeId,
                RequestedUnits = request.Units,
                ClinicId = request.ClinicId,
                Status = DonationContainerStatus.Requested
            };

            _containerRepo.Create(container);

            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}

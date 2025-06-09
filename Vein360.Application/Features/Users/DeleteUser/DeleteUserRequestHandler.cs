using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository;
using Vein360.Application.Repository.UserRepository;

namespace Vein360.Application.Features.Users.DeleteUser
{
    public class DeleteUserRequestHandler : IRequestHandler<DeleteUserRequest>
    {
        private readonly IUserRepository _userRepo;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserRequestHandler(IUserRepository userRepo, IUnitOfWork unitOfWork)
        {
            _userRepo = userRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepo.GetByIdAsync(request.Id, cancellationToken);

            _userRepo.Delete(user);

            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}

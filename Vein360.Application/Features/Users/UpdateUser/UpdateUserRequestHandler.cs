using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Common.Exceptions;
using Vein360.Application.Features.Users.CreateUser;
using Vein360.Application.Repository;
using Vein360.Application.Repository.UserRepository;

namespace Vein360.Application.Features.Users.UpdateUser
{
    public class UpdateUserRequestHandler : IRequestHandler<UpdateUserRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepo;



        public UpdateUserRequestHandler(IUnitOfWork unitOfWork, IUserRepository userRepo)
        {
            _userRepo = userRepo;
            _unitOfWork = unitOfWork;
        }
        async Task IRequestHandler<UpdateUserRequest>.Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            await EnsureUniqueEmail(request);

            var user = await _userRepo.GetByIdAsync(request.Id, cancellationToken);

            if (user != null)
            {
                user.Email = request.Email;
                user.IsAdmin = request.IsAdmin;
                user.IsDonor = request.IsDonor;
            }

            async Task EnsureUniqueEmail(UpdateUserRequest request)
            {
                bool emailAlreadyInUse = await _userRepo.IsExistAsync(x => x.Id != request.Id && x.Email.ToLower() == request.Email.ToLower());
                if (emailAlreadyInUse)
                {
                    throw new DuplicateEmailException();
                }
            }
        }
    }
}

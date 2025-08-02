using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Common.Exceptions;
using Vein360.Application.Common.Helpers.PasswordHelper;
using Vein360.Application.Repository;
using Vein360.Application.Repository.UserRepository;
using Vein360.Domain.Entities;

namespace Vein360.Application.Features.Users.CreateUser
{
    public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest>
    {
        private readonly IUserRepository _userRepo;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserRequestHandler(IUserRepository userRepo, IUnitOfWork unitOfWork)
        {
            _userRepo = userRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            await EnsureUniqueUsername(request);

            var user = new Vein360User
            {
                Username = request.Username,
                IsBuyer = request.IsBuyer,
                IsDonor = request.IsDonor,
                IsAdmin = request.IsAdmin,
                IsApiUser = request.IsApiUser,
            };

            user.Password = PasswordHelper.HashPassword(user, request.Password);

            _userRepo.Create(user);

            await _unitOfWork.SaveAsync(cancellationToken);


            async Task EnsureUniqueUsername(CreateUserRequest request)
            {
                bool usernameAlreadyInUse = await _userRepo.IsExistAsync(x => x.Username.ToLower() == request.Username.ToLower());
                if (usernameAlreadyInUse)
                {
                    throw new DuplicateUsernameException();
                }
            }
        }
    }
}

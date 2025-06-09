using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Common.Exceptions;
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
            await EnsureUniqueEmail(request);

            var user = new Vein360User
            {
                Email = request.Email,
                Password = request.Password,
                IsDonor = request.IsDonor,
                IsAdmin = request.IsAdmin
            };

            _userRepo.Create(user);

            await _unitOfWork.SaveAsync(cancellationToken);


            async Task EnsureUniqueEmail(CreateUserRequest request)
            {
                bool emailAlreadyInUse = await _userRepo.IsExistAsync(x => x.Email.ToLower() == request.Email.ToLower());
                if (emailAlreadyInUse)
                {
                    throw new DuplicateEmailException();
                }
            }
        }
    }
}

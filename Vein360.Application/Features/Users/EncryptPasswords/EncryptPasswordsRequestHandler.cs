using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Common.Helpers.PasswordHelper;
using Vein360.Application.Repository;
using Vein360.Application.Repository.UserRepository;

namespace Vein360.Application.Features.Users.EncryptPasswords
{
    public class EncryptPasswordsRequestHandler : IRequestHandler<EncryptPasswordsRequest>
    {
        private readonly IUserRepository _userRepo;
        private readonly IUnitOfWork _unitOfWork;

        public EncryptPasswordsRequestHandler(IUserRepository userRepo, IUnitOfWork unitOfWork)
        {
            _userRepo = userRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(EncryptPasswordsRequest request, CancellationToken cancellationToken)
        {
            var users = await _userRepo.GetAllAsync();

            foreach (var user in users)
            {
                user.Password = PasswordHelper.HashPassword(user, user.Username);
                _userRepo.Update(user);
            }

            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}

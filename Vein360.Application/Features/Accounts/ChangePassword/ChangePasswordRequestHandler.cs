using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Common.Exceptions;
using Vein360.Application.Common.Helpers.PasswordHelper;
using Vein360.Application.Repository;
using Vein360.Application.Repository.UserRepository;
using Vein360.Application.Service.AuthenticationService;

namespace Vein360.Application.Features.Accounts.ChangePassword
{
    public class ChangePasswordRequestHandler : IRequestHandler<ChangePasswordRequest>
    {
        private readonly IUserRepository _userRepo;
        private readonly IAuthInfoService _authInfo;
        private readonly IUnitOfWork _unitOfWork;

        public ChangePasswordRequestHandler(IUserRepository userRepo, IAuthInfoService authInfo, IUnitOfWork unitOfWork)
        {
            _userRepo = userRepo;
            _authInfo = authInfo;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(ChangePasswordRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepo.GetAsync(x => x.Username.ToLower() == _authInfo.UserName.ToLower());


            var passwordStatus = PasswordHelper.VerifyPassword(user, request.CurrentPassword);

            if (passwordStatus == PasswordVerificationResult.Failed)
            {
                throw new CustomValidationException("Current password is incorrect");
            }

            user.Password = PasswordHelper.HashPassword(user, request.NewPassword);

            user.FirstTimeLogin = false;

            _userRepo.Update(user);

            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}

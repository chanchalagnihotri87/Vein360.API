using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Common.Helpers.PasswordHelper;
using Vein360.Application.Features.Accounts.SignIn;
using Vein360.Application.Repository.UserRepository;
using Vein360.Application.Repository;
using Vein360.Application.Service.AuthenticationService;
using Vein360.Domain.Entities;
using Vein360.Application.Common.Helpers.Encryption;

namespace Vein360.Application.Features.Accounts.SingleSignIn
{
    public class SingleSignInRequestHandler : IRequestHandler<SingleSignInRequest, AuthenticationResponseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepo;
        private readonly IAuthenticationService _authenticationService;


        public SingleSignInRequestHandler(IUserRepository userRepo,
                                    IUnitOfWork unitOfWork,
                                    IAuthenticationService authenticationService)
        {
            _userRepo = userRepo;
            _unitOfWork = unitOfWork;
            _authenticationService = authenticationService;
        }


        public async Task<AuthenticationResponseDto> Handle(SingleSignInRequest request, CancellationToken cancellationToken)
        {
            AuthenticationResponseDto response = new AuthenticationResponseDto();

            Vein360User? user = default;

            switch (request.role)
            {
                case RoleType.Donor:
                    user = await _userRepo.GetAsync(x => x.Id == Convert.ToInt32(EncryptionHelper.Decrypt(request.Id)) && x.IsDonor);
                    break;
                case RoleType.Buyer:
                    user = await _userRepo.GetAsync(x => x.Id == Convert.ToInt32(EncryptionHelper.Decrypt(request.Id)) && x.IsBuyer);
                    break;
            }

            if (user == null)
            {
                throw new Exception("User not found");
            }

            //var passwordStatus = PasswordHelper.VerifyPassword(user, request.password);

            //if (passwordStatus == PasswordVerificationResult.Failed)
            //{
            //    throw new Exception("User not found");
            //}

            //if (passwordStatus == PasswordVerificationResult.SuccessRehashNeeded)
            //{
            //    await ReHashAndUpdatePassword(request, user, cancellationToken);
            //}

            string role = request.role.ToString();


            response.Token = _authenticationService.GenerateToken(user.Id, user.Username, role.ToLower());

            response.FirstTimeLogin = user.FirstTimeLogin;

            return response;
        }


    }
}

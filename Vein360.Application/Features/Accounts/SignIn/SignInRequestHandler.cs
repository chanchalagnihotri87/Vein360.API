using Microsoft.AspNetCore.Identity;
using Vein360.Application.Common.Helpers.PasswordHelper;
using Vein360.Application.Repository;
using Vein360.Application.Repository.UserRepository;
using Vein360.Application.Service.AuthenticationService;
using Vein360.Domain.Entities;

namespace Vein360.Application.Features.Accounts.SignIn
{
    public class SignInRequestHandler : IRequestHandler<SignInRequest, AuthenticationResponseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepo;
        private readonly IAuthenticationService _authenticationService;


        public SignInRequestHandler(IUserRepository userRepo,
                                    IUnitOfWork unitOfWork,
                                    IAuthenticationService authenticationService)
        {
            _userRepo = userRepo;
            _unitOfWork = unitOfWork;
            _authenticationService = authenticationService;
        }


        public async Task<AuthenticationResponseDto> Handle(SignInRequest request, CancellationToken cancellationToken)
        {
            AuthenticationResponseDto response = new AuthenticationResponseDto();

            Vein360User? user = default;

            switch (request.role)
            {
                case RoleType.Admin:
                    user = await _userRepo.GetAsync(x => x.Username.ToLower() == request.username.ToLower() && x.IsAdmin);
                    break;
                case RoleType.Donor:
                    user = await _userRepo.GetAsync(x => x.Username.ToLower() == request.username.ToLower() && x.IsDonor);
                    break;
                case RoleType.Buyer:
                    user = await _userRepo.GetAsync(x => x.Username.ToLower() == request.username.ToLower() && x.IsBuyer);
                    break;
                case RoleType.ApiUser:
                    user = await _userRepo.GetAsync(x => x.Username.ToLower() == request.username.ToLower() && x.IsApiUser);
                    break;
            }

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var passwordStatus = PasswordHelper.VerifyPassword(user, request.password);

            if (passwordStatus == PasswordVerificationResult.Failed)
            {
                throw new Exception("User not found");
            }

            if (passwordStatus == PasswordVerificationResult.SuccessRehashNeeded)
            {
                await ReHashAndUpdatePassword(request, user, cancellationToken);
            }

            string role = request.role.ToString();
        

            response.Token = _authenticationService.GenerateToken(user.Id, user.Username, role.ToLower());

            response.FirstTimeLogin = user.FirstTimeLogin;

            return response;

            async Task ReHashAndUpdatePassword(SignInRequest request, Vein360User user, CancellationToken cancellationToken)
            {
                user.Password = PasswordHelper.HashPassword(user, request.password);

                _userRepo.Update(user);

                await _unitOfWork.SaveAsync(cancellationToken);
            }
        }


    }
}

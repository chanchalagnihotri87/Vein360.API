using Vein360.Application.Repository.UserRepository;
using Vein360.Application.Service.AuthenticationService;
using Vein360.Domain.Entities;

namespace Vein360.Application.Features.Accounts.SignIn
{
    public class SignInRequestHandler : IRequestHandler<SignInRequest, string>
    {
        private readonly IUserRepository _userRepo;
        private readonly IAuthenticationService _authenticationService;


        public SignInRequestHandler(IUserRepository userRepo,
                                    IAuthenticationService authenticationService)
        {
            _userRepo = userRepo;
            _authenticationService = authenticationService;
        }


        public async Task<string> Handle(SignInRequest request, CancellationToken cancellationToken)
        {
            Vein360User user;

            switch (request.role)
            {
                case RoleType.Admin:
                    user = await _userRepo.GetAsync(x => x.Email.ToLower() == request.email.ToLower() && x.Password == request.password && x.IsAdmin);
                    break;
                case RoleType.Donor:
                    user = await _userRepo.GetAsync(x => x.Email.ToLower() == request.email.ToLower() && x.Password == request.password && x.IsDonor);
                    break;
                default:
                    user = await _userRepo.GetAsync(x => x.Email.ToLower() == request.email.ToLower() && x.Password == request.password);
                    break;
            }



            if (user == null)
            {
                throw new Exception("User not found");
            }

            var token = _authenticationService.GenerateToken(user.Id, user.Email);

            return token;
        }
    }
}

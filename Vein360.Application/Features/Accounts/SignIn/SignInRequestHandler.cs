using Microsoft.Extensions.Configuration;
using Vein360.Application.Repository.UserRepository;
using Vein360.Application.Service.AuthenticationService;

namespace Vein360.Application.Features.Accounts.SignIn
{
    public class SignInRequestHandler : IRequestHandler<SignInRequest, string>
    {
        private readonly IUserRepository _userRepo;
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationService _authenticationService;


        public SignInRequestHandler(IUserRepository userRepo, IConfiguration configuration,
            IAuthenticationService authenticationService)
        {
            _userRepo = userRepo;
            _configuration = configuration;
            _authenticationService = authenticationService;
        }


        public async Task<string> Handle(SignInRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepo.GetAsync(x => x.Email.ToLower() == request.email.ToLower() && x.Password == request.password);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var token = _authenticationService.GenerateToken(user.Id, user.Email);

            return token;
        }
    }
}

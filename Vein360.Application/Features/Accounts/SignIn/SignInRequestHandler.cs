using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository.UserRepository;

namespace Vein360.Application.Features.Accounts.SignIn
{
    public class SignInRequestHandler : IRequestHandler<SignInRequest>
    {
        private readonly IUserRepository _userRepo;

        public SignInRequestHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task Handle(SignInRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepo.GetAsync(x => x.Email.ToLower() == request.email.ToLower() && x.Password == request.password);

            if (user == null)
            {
                throw new Exception("User not found");
            }
        }
    }
}

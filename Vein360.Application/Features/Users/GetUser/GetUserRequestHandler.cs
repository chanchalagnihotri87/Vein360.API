using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository.UserRepository;

namespace Vein360.Application.Features.Users.GetUser
{
    public class GetUserRequestHandler : IRequestHandler<GetUserRequest, UserDto>
    {
        private readonly IUserRepository _userRepo;

        public GetUserRequestHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<UserDto> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepo.GetByIdAsync(request.Id);

            return user.Adapt<UserDto>();
        }
    }
}

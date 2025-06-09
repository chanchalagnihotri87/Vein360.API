using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository.UserRepository;

namespace Vein360.Application.Features.Users.GetUsers
{
    public class GetUsersRequestHandler : IRequestHandler<GetUsersRequest, List<UserDto>>
    {
        private readonly IUserRepository _userRepo;

        public GetUsersRequestHandler(IUserRepository userRepo)
        {
            _userRepo= userRepo;
        }

        public async Task<List<UserDto>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
           var users= await _userRepo.GetAllAsync(cancellationToken);

            return users.Adapt < List<UserDto>>();
        }
    }
}

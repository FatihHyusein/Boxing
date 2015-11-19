using Boxing.Contracts;
using Boxing.Contracts.Dto;
using Boxing.Contracts.Requests.Users;
using Boxing.Core.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Core.Handlers.Features.Users
{
    public class GetUserHandler : IRequestHandler<GetUserRequest, UserDto>
    {
        public async Task<UserDto> HandleAsync(GetUserRequest request)
        {
            return new UserDto();
        }
    }
}

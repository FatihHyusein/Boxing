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
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, UserDto>
    {
        public async Task<UserDto> HandleAsync(CreateUserRequest request)
        {
            return new UserDto
            {
                Id = "1",
                Rating = 0
            };
        }
    }
}

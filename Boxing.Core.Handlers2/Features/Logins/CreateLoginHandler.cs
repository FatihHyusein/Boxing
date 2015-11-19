using Boxing.Contracts.Dto;
using Boxing.Contracts.Requests.Logins;
using Boxing.Core.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Core.Handlers.Features.Logins
{
    public class CreateLoginHandler : IRequestHandler<CreateLoginRequest, UserDto>
    {
        public async Task<UserDto> HandleAsync(CreateLoginRequest request)
        {
            return new UserDto()
            {
                Id = "555",
                AuthToken = "thetoken"
            };
        }
    }
}

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
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersRequest, IEnumerable<UserDto>>
    {
        public async Task<IEnumerable<UserDto>> HandleAsync(GetAllUsersRequest request)
        {
            return new List<UserDto>() {
                new UserDto()
                {

                }
            };
        }
    }
}

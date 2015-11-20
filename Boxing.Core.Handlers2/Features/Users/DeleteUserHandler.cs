using Boxing.Contracts.Requests.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Core.Handlers.Features.Users
{
    public class DeleteUserHandler : CommandHandler<DeleteUserRequest>
    {
        protected override async Task HandleCore(DeleteUserRequest command)
        {
            
        }
    }
}

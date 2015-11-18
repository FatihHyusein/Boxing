using Boxing.Contracts.Requests.Logins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Core.Handlers.Features.Logins
{
    public class CreateLoginHandler : CommandHandler<CreateLoginRequest>
    {
        protected override async Task HandleCore(CreateLoginRequest command)
        {
            //
        }
    }
}

using Boxing.Contracts.Requests.Logins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Core.Handlers.Features.Logins
{
    public class DeleteLoginHandler : CommandHandler<DeleteLoginRequest>
    {
        protected override async Task HandleCore(DeleteLoginRequest command)
        {
            //
        }
    }
}

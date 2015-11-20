using Boxing.Contracts.Requests.Matches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Core.Handlers.Features.Matches
{
    public class DeletePredictionHandler :CommandHandler<DeletePredictionRequest>
    {
        protected override async Task HandleCore(DeletePredictionRequest command)
        {
        }
    }
}

using Boxing.Contracts.Requests.Matches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Core.Handlers.Features.Matches
{
    public class CreatePredictionHandler : CommandHandler<CreatePredictionRequest>
    {
        protected override async Task HandleCore(CreatePredictionRequest command)
        {

        }
    }
}

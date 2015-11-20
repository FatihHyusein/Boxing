using Boxing.Contracts.Requests.Matches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Core.Handlers.Features.Matches
{
    public class UpdatePredictionHandler : CommandHandler<UpdatePredictionRequest>
    {
        protected override async Task HandleCore(UpdatePredictionRequest command)
        {
        }
    }
}

using Boxing.Contracts.Dto;
using Boxing.Contracts.Requests.Matches;
using Boxing.Core.Handlers;
using Boxing.Core.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Core.Handlers.Features.Matches
{
    public class CreateMatchHandler : IRequestHandler<CreateMatchRequest, MatchDto>
    {
        public async Task<MatchDto> HandleAsync(CreateMatchRequest request)
        {
            return new MatchDto
            {
                Id = "1",
                Dsecription = "Match description"
            };
        }
    }
}

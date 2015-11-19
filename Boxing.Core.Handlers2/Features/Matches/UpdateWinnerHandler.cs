using Boxing.Contracts.Dto;
using Boxing.Contracts.Requests.Matches;
using Boxing.Core.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Core.Handlers.Features.Matches
{
    public class UpdateWinnerHandler : IRequestHandler<UpdateWinnerRequest, MatchDto>
    {
        public async Task<MatchDto> HandleAsync(UpdateWinnerRequest request)
        {
            //update user ratings
            return new MatchDto
            {
                Id = "1",
                Dsecription = "Match description",
                Winner = "Snoop"
            };
        }
    }
}

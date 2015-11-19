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
    public class GetAllMatchesHandler : IRequestHandler<GetAllMatchesRequest, IEnumerable<MatchDto>>
    {
        public async Task<IEnumerable<MatchDto>> HandleAsync(GetAllMatchesRequest request)
        {
            return new List<MatchDto>()
            {

            };
        }
    }
}

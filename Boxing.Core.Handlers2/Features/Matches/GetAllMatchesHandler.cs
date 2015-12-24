using AutoMapper;
using Boxing.Contracts.Dto;
using Boxing.Contracts.Requests.Matches;
using Boxing.Core.Handlers.Interfaces;
using Boxing.Core.Sql;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Core.Handlers.Features.Matches
{
    public class GetAllMatchesHandler : IRequestHandler<GetAllMatchesRequest, IEnumerable<MatchDto>>
    {

        private readonly BoxingContext _db;

        public GetAllMatchesHandler(BoxingContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<MatchDto>> HandleAsync(GetAllMatchesRequest request)
        {
            var takeCount = (request.RequestParams.Take == 0) ? 20 : request.RequestParams.Take;

            return (await _db.Matches
                .ToListAsync()).OrderBy(t => t.DateOfMatch)
                .Select(Mapper.Map<MatchDto>);
        }
    }
}

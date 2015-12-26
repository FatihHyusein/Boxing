using Boxing.Contracts.Dto;
using Boxing.Contracts.Requests.Matches;
using Boxing.Core.Handlers;
using Boxing.Core.Handlers.Interfaces;
using Boxing.Core.Sql;
using Boxing.Core.Sql.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Core.Handlers.Features.Matches
{
    public class CreateMatchHandler : IRequestHandler<CreateMatchRequest, PostPutMatchDto>
    {
        private readonly BoxingContext _db;

        public CreateMatchHandler(BoxingContext db)
        {
            _db = db;
        }
        public async Task<PostPutMatchDto> HandleAsync(CreateMatchRequest request)
        {
            var newMatch = AutoMapper.Mapper.Map<MatchEntity>(request.Match);

            _db.Matches.Add(newMatch);
            await _db.SaveChangesAsync().ConfigureAwait(false);

            return AutoMapper.Mapper.Map<PostPutMatchDto>(newMatch);
        }
    }
}

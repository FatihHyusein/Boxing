using Boxing.Contracts.Dto;
using Boxing.Contracts.Requests.Matches;
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
    public class UpdateWinnerHandler : IRequestHandler<UpdateWinnerRequest, MatchDto>
    {
        private readonly BoxingContext _db;

        public UpdateWinnerHandler(BoxingContext db)
        {
            _db = db;
        }
        public async Task<MatchDto> HandleAsync(UpdateWinnerRequest request)
        {
            var match = await _db.Matches.FindAsync(request.Match.Id).ConfigureAwait(false);

            if (match == null)
            {
                throw new ArgumentNullException();
            }

            match.Winner = request.Match.Winner;
            await _db.SaveChangesAsync().ConfigureAwait(false);

            return AutoMapper.Mapper.Map<MatchDto>(match);
        }
    }
}

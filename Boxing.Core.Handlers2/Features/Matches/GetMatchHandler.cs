using AutoMapper;
using Boxing.Contracts;
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
    public class GetMatchHandler : IRequestHandler<GetMatchRequest, MatchDto>
    {
        private readonly BoxingContext _db;

        public GetMatchHandler(BoxingContext db)
        {
            _db = db;
        }

        public async Task<MatchDto> HandleAsync(GetMatchRequest request)
        {
            var match = await _db.Matches.FindAsync(request.Id).ConfigureAwait(false);
            if (match == null)
            {
                throw new ArgumentNullException();
            }

            match.Predictions = await _db.Predictions.Where(p => p.MatchId == request.Id).ToListAsync().ConfigureAwait(false);

            var matchDetail = Mapper.Map<MatchDto>(match);
            matchDetail.CurrentPrediction = Mapper.Map<PredictionDto>(match.Predictions.Where(u => u.UserId == Constants.Headers.CurrentUserId).FirstOrDefault());
            return matchDetail;
        }
    }
}

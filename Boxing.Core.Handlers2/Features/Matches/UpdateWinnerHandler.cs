using Boxing.Contracts.Dto;
using Boxing.Contracts.Requests.Matches;
using Boxing.Core.Handlers.Interfaces;
using Boxing.Core.Sql;
using Boxing.Core.Sql.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

            if (match.Status == "Canceled")
            {
                throw new ArgumentException();
            }

            if (match.Winner == null)
            {
                var predictions = await _db.Predictions.Include(p=>p.User.Rating).Where(p => p.MatchId == request.Match.Id).Include(i => i.User).ToListAsync();
                foreach (var prediction in predictions)
                {
                    prediction.IsClosedMatch = true;
                    if (prediction.Winner.Equals(request.Match.Winner))
                    {
                        prediction.User.Rating.CorrectPredictionsCount++;
                        prediction.User.Rating.TotalPredictions++;
                        prediction.User.Rating.Rating += 5;
                    }
                    else
                    {
                        prediction.User.Rating.WrongPredictionsCount++;
                        prediction.User.Rating.TotalPredictions++;
                        prediction.User.Rating.Rating -= 2;
                    }
                }
            }

            match.Winner = request.Match.Winner;
            await _db.SaveChangesAsync().ConfigureAwait(false);

            return AutoMapper.Mapper.Map<MatchDto>(match);
        }
    }
}

using Boxing.Contracts;
using Boxing.Contracts.Dto;
using Boxing.Contracts.Requests.Matches;
using Boxing.Core.Sql;
using Boxing.Core.Sql.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Core.Handlers.Features.Matches
{
    public class CreatePredictionHandler : CommandHandler<CreatePredictionRequest>
    {
        private readonly BoxingContext _db;

        public CreatePredictionHandler(BoxingContext db)
        {
            _db = db;
        }

        protected override async Task HandleCore(CreatePredictionRequest request)
        {
            var match = await _db.Matches.FindAsync(request.Prediction.MatchId).ConfigureAwait(false);
            if (match.Winner != null)
            {
                throw new ArgumentException();
            }

            var prediction = AutoMapper.Mapper.Map<PredictionEntity>(request.Prediction);
            prediction.UserId = Constants.Headers.CurrentUserId;

            _db.Predictions.Add(prediction);
            await _db.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}

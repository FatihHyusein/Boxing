using Boxing.Contracts.Requests.Matches;
using Boxing.Core.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Core.Handlers.Features.Matches
{
    public class UpdatePredictionHandler : CommandHandler<UpdatePredictionRequest>
    {
        private readonly BoxingContext _db;

        public UpdatePredictionHandler(BoxingContext db)
        {
            _db = db;
        }

        protected override async Task HandleCore(UpdatePredictionRequest request)
        {
            var prediction = await _db.Predictions.FindAsync(request.Prediction.Id).ConfigureAwait(false);

            if (prediction == null)
            {
                throw new ArgumentNullException();
            }

            var match = await _db.Matches.FindAsync(prediction.MatchId).ConfigureAwait(false);
            if (match.Winner != null)
            {
                throw new ArgumentException();
            }

            prediction.Winner = request.Prediction.Winner;

            await _db.SaveChangesAsync().ConfigureAwait(false);
        }

    }
}

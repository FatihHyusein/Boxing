using Boxing.Contracts.Requests.Matches;
using Boxing.Core.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Core.Handlers.Features.Matches
{
    public class DeletePredictionHandler :CommandHandler<DeletePredictionRequest>
    {
        private readonly BoxingContext _db;

        public DeletePredictionHandler(BoxingContext db)
        {
            _db = db;
        }

        protected override async Task HandleCore(DeletePredictionRequest request)
        {
            var prediction = await _db.Predictions.FindAsync(request.PredictionId).ConfigureAwait(false);

            if (prediction == null)
            {
                throw new ArgumentNullException("Can not find prediction with this id.");
            }

            var match = await _db.Matches.FindAsync(prediction.MatchId).ConfigureAwait(false);
            if (match.Winner != null)
            {
                throw new ArgumentException("The match has winner. Can not delete prediction.");
            }

            _db.Predictions.Remove(prediction);
            await _db.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}

using Boxing.Contracts.Requests.Matches;
using Boxing.Core.Sql;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Core.Handlers.Features.Matches
{
    public class CancelMatchHandler : CommandHandler<CancelMatchRequest>
    {
        private readonly BoxingContext _db;

        public CancelMatchHandler(BoxingContext db)
        {
            _db = db;
        }

        protected override async Task HandleCore(CancelMatchRequest request)
        {
            var match = await _db.Matches.FindAsync(request.Id).ConfigureAwait(false);

            if (match.Winner != null)
            {
                throw new ArgumentException();
            }

            match.Status = "Canceled";
            var predictions = await _db.Predictions.Where(p => p.MatchId == request.Id).ToListAsync().ConfigureAwait(false);
            _db.Predictions.RemoveRange(predictions);

            await _db.SaveChangesAsync().ConfigureAwait(false);
        }
    }

}

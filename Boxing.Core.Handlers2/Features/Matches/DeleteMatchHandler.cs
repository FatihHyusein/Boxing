using Boxing.Contracts.Requests.Matches;
using Boxing.Core.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Core.Handlers.Features.Matches
{
    public class DeleteMatchHandler : CommandHandler<DeleteMatchRequest>
    {
        private readonly BoxingContext _db;

        public DeleteMatchHandler(BoxingContext db)
        {
            _db = db;
        }

        protected override async Task HandleCore(DeleteMatchRequest request)
        {
            var match = await _db.Matches.FindAsync(request.MatchId).ConfigureAwait(false);

            if (match == null)
            {
                throw new ArgumentNullException("Can not find match with this Id.");
            }

            _db.Matches.Remove(match);
            await _db.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}

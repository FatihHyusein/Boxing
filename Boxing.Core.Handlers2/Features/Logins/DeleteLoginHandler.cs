using Boxing.Contracts;
using Boxing.Contracts.Requests.Logins;
using Boxing.Core.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Core.Handlers.Features.Logins
{
    public class DeleteLoginHandler : CommandHandler<DeleteLoginRequest>
    {
        private readonly BoxingContext _db;

        public DeleteLoginHandler(BoxingContext db)
        {
            _db = db;
        }

        protected override async Task HandleCore(DeleteLoginRequest command)
        {
            var user = await _db.Users.FindAsync(Constants.Headers.CurrentUserId).ConfigureAwait(false);

            if (user == null)
            {
                throw new ArgumentNullException("The user with this auth-token is logged off or does not exist.");
            }

            user.AuthToken = null;
            await _db.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}

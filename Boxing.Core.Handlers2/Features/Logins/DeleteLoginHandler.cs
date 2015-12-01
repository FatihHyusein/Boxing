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
            var user = await _db.Users.FindAsync(command.Id).ConfigureAwait(false);

            if (user == null)
            {
                throw new ArgumentNullException();
            }

            user.AuthToken = null;
            await _db.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}

using Boxing.Contracts.Requests.Users;
using Boxing.Core.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Core.Handlers.Features.Users
{
    public class DeleteUserHandler : CommandHandler<DeleteUserRequest>
    {
        private readonly BoxingContext _db;

        public DeleteUserHandler(BoxingContext db)
        {
            _db = db;
        }

        protected override async Task HandleCore(DeleteUserRequest command)
        {
            var user = await _db.Users.FindAsync(command.UserId).ConfigureAwait(false);

            if (user == null)
            {
                throw new ArgumentNullException();
            }

            _db.Users.Remove(user);
            await _db.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}

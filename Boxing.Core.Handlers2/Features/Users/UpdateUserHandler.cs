using AutoMapper;
using Boxing.Contracts;
using Boxing.Contracts.Dto;
using Boxing.Contracts.Requests.Users;
using Boxing.Core.Handlers.Interfaces;
using Boxing.Core.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Core.Handlers.Features.Users
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UserDto>
    {
        private readonly BoxingContext _db;

        public UpdateUserHandler(BoxingContext db)
        {
            _db = db;
        }

        public async Task<UserDto> HandleAsync(UpdateUserRequest request)
        {
            if (request.User.Id != Constants.Headers.CurrentUserId)
            {
                throw new ArgumentException();
            }

            var user = await _db.Users.FindAsync(request.User.Id).ConfigureAwait(false);
            if (user == null)
            {
                throw new ArgumentNullException();
            }

            user.FullName = request.User.FullName;

            await _db.SaveChangesAsync().ConfigureAwait(false);

            return Mapper.Map<UserDto>(user);
        }
    }
}

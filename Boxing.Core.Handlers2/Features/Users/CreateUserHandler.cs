using AutoMapper;
using Boxing.Contracts.Dto;
using Boxing.Contracts.Requests.Users;
using Boxing.Core.Handlers.Interfaces;
using Boxing.Core.Sql;
using Boxing.Core.Sql.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Core.Handlers.Features.Users
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, UserDto>
    {
        private readonly BoxingContext _db;

        public CreateUserHandler(BoxingContext db)
        {
            _db = db;
        }

        public async Task<UserDto> HandleAsync(CreateUserRequest request)
        {
            //var entity = Mapper.Map<UserEntity>(request.User);
            _db.Users.Add(new UserEntity()
            {
                FullName = request.User.FullName
            });
            await _db.SaveChangesAsync().ConfigureAwait(false);

            var ddd = (await _db.Users.FindAsync(int.Parse(request.User.Password)).ConfigureAwait(false));


            return new UserDto
            {
                Id = ddd.FullName,
                Rating = ddd.Id
            };
        }
    }
}

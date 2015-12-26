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
            var entity = Mapper.Map<UserEntity>(request.User);

            entity.Rating = new RatingEntity();
            _db.Users.Add(entity);

            await _db.SaveChangesAsync().ConfigureAwait(false);
            
            return new UserDto
            {
                Id = entity.Id,
                Rating = Mapper.Map<RatingDto>(entity.Rating)
            };
        }
    }
}

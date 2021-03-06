﻿using AutoMapper;
using Boxing.Contracts.Dto;
using Boxing.Contracts.Requests.Logins;
using Boxing.Core.Handlers.Interfaces;
using Boxing.Core.Sql;
using Boxing.Core.Sql.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Core.Handlers.Features.Logins
{
    public class CreateLoginHandler : IRequestHandler<CreateLoginRequest, UserDto>
    {
        private readonly BoxingContext _db;

        public CreateLoginHandler(BoxingContext db)
        {
            _db = db;
        }

        public async Task<UserDto> HandleAsync(CreateLoginRequest request)
        {
            var entity = Mapper.Map<UserEntity>(request.User);

            var user = _db.Users.Where(u => u.Username == request.User.Username).FirstOrDefault();

            if (user == null)
            {
                throw new ArgumentNullException("User with this username does not exist.");
            }
            else if (request.User.Password != user.Password)
            {
                throw new ArgumentException("Username and passwort do not match.");
            }
            user.AuthToken = Guid.NewGuid().ToString();

            if (user.Username == "admin")
            {
                user.AuthToken = string.Concat("securetoken", Guid.NewGuid().ToString());
            }

            await _db.SaveChangesAsync().ConfigureAwait(false);

            return new UserDto()
            {
                Id = user.Id,
                AuthToken = user.AuthToken
            };
        }
    }
}

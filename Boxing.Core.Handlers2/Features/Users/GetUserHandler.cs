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
    public class GetUserHandler : IRequestHandler<GetUserRequest, UserPreviewDto>
    {
        private readonly BoxingContext _db;

        public GetUserHandler(BoxingContext db)
        {
            _db = db;
        }

        public async Task<UserPreviewDto> HandleAsync(GetUserRequest request)
        {
            var user = await _db.Users.FindAsync(request.Id).ConfigureAwait(false);
            if (user == null)
            {
                throw new ArgumentNullException();
            }

            var userDetail = Mapper.Map<UserPreviewDto>(user);
            return userDetail;
        }
    }
}

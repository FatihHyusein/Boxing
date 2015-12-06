﻿using AutoMapper;
using Boxing.Contracts.Dto;
using Boxing.Contracts.Requests.Users;
using Boxing.Core.Handlers.Interfaces;
using Boxing.Core.Sql;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Core.Handlers.Features.Users
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersRequest, IEnumerable<UserPreviewDto>>
    {

        private readonly BoxingContext _db;

        public GetAllUsersHandler(BoxingContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<UserPreviewDto>> HandleAsync(GetAllUsersRequest request)
        {
            var takeCount = (request.RequestParams.Take == 0) ? 20 : request.RequestParams.Take;

            return (await _db.Users
                .ToListAsync()).Select(Mapper.Map<UserPreviewDto>);
        }
    }
}

using AutoMapper;
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
            try
            {
                if (request.RequestParams.SortingOrder.Equals("DESC"))
                {
                    return (await _db.Users.Include(u => u.Rating)
                    .ToListAsync())
                    .Where(t => t.FullName != null && t.FullName.Contains(request.RequestParams.Search) ||
                    t.Username.Contains(request.RequestParams.Search))
                    .OrderByDescending(t => t.GetType().GetProperty(request.RequestParams.SortBy).GetValue(t, null))
                    .Skip(request.RequestParams.Skip)
                    .Take(request.RequestParams.Take)
                    .Select(Mapper.Map<UserPreviewDto>);
                }
                else
                {
                    return (await _db.Users.Include(u => u.Rating)
                    .ToListAsync())
                    .Where(t => t.FullName != null && t.FullName.Contains(request.RequestParams.Search) ||
                    t.Username.Contains(request.RequestParams.Search))
                    .OrderBy(t => t.GetType().GetProperty(request.RequestParams.SortBy).GetValue(t, null))
                    .Skip(request.RequestParams.Skip)
                    .Take(request.RequestParams.Take)
                    .Select(Mapper.Map<UserPreviewDto>);
                }
            }
            catch
            {
                throw new ArgumentException();
            }
        }
    }
}

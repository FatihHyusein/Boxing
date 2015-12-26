using AutoMapper;
using Boxing.Contracts.Dto;
using Boxing.Contracts.Requests.Matches;
using Boxing.Core.Handlers.Interfaces;
using Boxing.Core.Sql;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Core.Handlers.Features.Matches
{
    public class PendingPastMatchesHandler : IRequestHandler<PendingPastMatchesRequest, IEnumerable<MatchDto>>
    {

        private readonly BoxingContext _db;

        public PendingPastMatchesHandler(BoxingContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<MatchDto>> HandleAsync(PendingPastMatchesRequest request)
        {
            try
            {
                if (request.RequestParams.SortingOrder.Equals("DESC"))
                {
                    return (await _db.Matches
                    .ToListAsync())
                    .Where(m => m.DateOfMatch.CompareTo(DateTime.Now) < 0 && m.Winner == null)
                    .OrderByDescending(t => t.GetType().GetProperty(request.RequestParams.SortBy).GetValue(t, null))
                    .Skip(request.RequestParams.Skip)
                    .Take(request.RequestParams.Take)
                    .Select(Mapper.Map<MatchDto>);
                }
                else
                {
                    return (await _db.Matches
                    .ToListAsync())
                    .Where(m => m.DateOfMatch.CompareTo(DateTime.Now) < 0 && m.Winner == null)
                    .OrderBy(t => t.GetType().GetProperty(request.RequestParams.SortBy).GetValue(t, null))
                    .Skip(request.RequestParams.Skip)
                    .Take(request.RequestParams.Take)
                    .Select(Mapper.Map<MatchDto>);
                }
            }
            catch
            {
                throw new ArgumentException();
            }
        }
    }
}

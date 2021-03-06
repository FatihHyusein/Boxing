﻿using AutoMapper;
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
                    .Where(m => m.DateOfMatch.CompareTo(DateTime.Now) < 0 && m.Winner == null && m.Status != "Canceled")
                    .Where(t => t.Boxer1.Contains(request.RequestParams.Search) ||
                    t.Boxer2.Contains(request.RequestParams.Search) ||
                    t.DateOfMatch.Equals(request.RequestParams.Search) ||
                    t.Dsecription != null && t.Dsecription.Contains(request.RequestParams.Search) ||
                    t.Place != null && t.Place.Contains(request.RequestParams.Search) ||
                    t.Status != null && t.Status.Equals(request.RequestParams.Search))
                    .OrderByDescending(t => t.GetType().GetProperty(request.RequestParams.SortBy).GetValue(t, null))
                    .Skip(request.RequestParams.Skip)
                    .Take(request.RequestParams.Take)
                    .Select(Mapper.Map<MatchDto>);
                }
                else
                {
                    return (await _db.Matches
                    .ToListAsync())
                    .Where(m => m.DateOfMatch.CompareTo(DateTime.Now) < 0 && m.Winner == null && m.Status != "Canceled")
                    .Where(t => t.Boxer1.Contains(request.RequestParams.Search) ||
                    t.Boxer2.Contains(request.RequestParams.Search) ||
                    t.DateOfMatch.Equals(request.RequestParams.Search) ||
                    t.Dsecription != null && t.Dsecription.Contains(request.RequestParams.Search) ||
                    t.Place != null && t.Place.Contains(request.RequestParams.Search) ||
                    t.Status != null && t.Status.Equals(request.RequestParams.Search))
                    .OrderBy(t => t.GetType().GetProperty(request.RequestParams.SortBy).GetValue(t, null))
                    .Skip(request.RequestParams.Skip)
                    .Take(request.RequestParams.Take)
                    .Select(Mapper.Map<MatchDto>);
                }
            }
            catch
            {
                throw new ArgumentException("Chech your request parameters. Pay attention on small and big letters!");
            }
        }
    }
}

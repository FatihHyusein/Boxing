using AutoMapper;
using Boxing.Contracts.Dto;
using Boxing.Contracts.Requests.Matches;
using Boxing.Core.Handlers.Interfaces;
using Boxing.Core.Sql;
using Boxing.Core.Sql.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Core.Handlers.Features.Matches
{
    public class UpdateMatchHandler : IRequestHandler<UpdateMatchRequest, PostPutMatchDto>
    {
        private readonly BoxingContext _db;

        public UpdateMatchHandler(BoxingContext db)
        {
            _db = db;
        }
        public async Task<PostPutMatchDto> HandleAsync(UpdateMatchRequest request)
        {
            var match = await _db.Matches.FindAsync(request.Match.Id).ConfigureAwait(false);

            if (match == null)
            {
                throw new ArgumentNullException();
            }
            match.Boxer1 = request.Match.Boxer1;
            match.Boxer2 = request.Match.Boxer2;
            match.DateOfMatch = request.Match.DateOfMatch;
            match.Dsecription = request.Match.Dsecription;
            match.Place = request.Match.Place;

            await _db.SaveChangesAsync().ConfigureAwait(false);

            return AutoMapper.Mapper.Map<PostPutMatchDto>(match);
        }
    }
}

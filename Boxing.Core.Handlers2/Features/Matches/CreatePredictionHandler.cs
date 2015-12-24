using Boxing.Contracts.Dto;
using Boxing.Contracts.Requests.Matches;
using Boxing.Core.Sql;
using Boxing.Core.Sql.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Core.Handlers.Features.Matches
{
    public class CreatePredictionHandler : CommandHandler<CreatePredictionRequest>
    {
        private readonly BoxingContext _db;

        public CreatePredictionHandler(BoxingContext db)
        {
            _db = db;
        }

        protected override async Task HandleCore(CreatePredictionRequest request)
        {
            var prediction = AutoMapper.Mapper.Map<PredictionEntity>(request.Prediction);
            _db.Predictions.Add(prediction);
            await _db.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}

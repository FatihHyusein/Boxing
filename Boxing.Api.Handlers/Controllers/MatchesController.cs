using Boxing.Api.Handlers.Filters;
using Boxing.Contracts;
using Boxing.Contracts.Dto;
using Boxing.Contracts.Requests.Matches;
using Boxing.Core.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Boxing.Api.Handlers.Controllers
{
    public class MatchesController : ApiController
    {
        private readonly IMediator _mediator;
        private string _authToken;

        public MatchesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);

            var headers = controllerContext.Request.Headers;
            IEnumerable<string> values;
            if (headers.TryGetValues(Constants.Headers.AuthTokenHeader, out values))
                _authToken = values.FirstOrDefault();
        }

        [Admin]
        [HttpPost]
        public async Task<HttpResponseMessage> CreateMatch([FromBody] MatchDto match)
        {
            var request = new CreateMatchRequest()
            {
                Match = match
            };

            MatchDto addedMatch = await _mediator.ExecuteAsync(request).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.Created, addedMatch);
        }

        [Admin]
        [HttpPut]
        public async Task<MatchDto> UpdateWinner(int id, [FromBody] MatchDto match)
        {
            match.Id = id;
            var request = new UpdateWinnerRequest
            {
                Match = match
            };
            return await _mediator.ExecuteAsync(request).ConfigureAwait(false);
        }

        [Auth]
        [HttpGet]
        public async Task<IEnumerable<MatchDto>> GetAllMatches([FromUri]RequestParamsDto reqParams)
        {
            var request = new GetAllMatchesRequest()
            {
                RequestParams = reqParams
            };
            return await _mediator.ExecuteAsync(request).ConfigureAwait(false);
        }

        [Auth]
        [HttpPost]
        [Route("api/matches/{matchId}/predictions")]
        public async Task<HttpResponseMessage> CreatePrediction([FromUri]int matchId, [FromBody] PredictionDto prediction)
        {
            var request = new CreatePredictionRequest()
            {
                MatchId = matchId,
                prediction = prediction
            };

            await _mediator.ExecuteAsync(request).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [Auth]
        [HttpPut]
        [Route("api/matches/{matchId}/predictions/{predictionId}")]
        public async Task<HttpResponseMessage> UpdatePrediction([FromUri]int matchId, [FromUri] string predictionId, [FromBody] PredictionDto prediction)
        {
            var request = new CreatePredictionRequest()
            {
                MatchId = matchId,
                prediction = prediction
            };

            await _mediator.ExecuteAsync(request).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Auth]
        [HttpDelete]
        [Route("api/matches/{matchId}/predictions/{predictionId}")]
        public async Task DeletePrediction([FromUri]int matchId, [FromUri] string predictionId)
        {
            var request = new CreatePredictionRequest()
            {
                MatchId = matchId,

            };

            await _mediator.ExecuteAsync(request).ConfigureAwait(false);
        }
    }
}

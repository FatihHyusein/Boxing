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
        public async Task<HttpResponseMessage> CreateMatch([FromBody] PostPutMatchDto match)
        {
            var request = new CreateMatchRequest()
            {
                Match = match
            };

            PostPutMatchDto addedMatch = await _mediator.ExecuteAsync(request).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.Created, addedMatch);
        }

        [Admin]
        [HttpPut]
        public async Task<HttpResponseMessage> UpdateMatch([FromUri] int id, [FromBody] PostPutMatchDto Match)
        {
            Match.Id = id;
            var request = new UpdateMatchRequest()
            {
                Match = Match
            };

            PostPutMatchDto updatedMatch = await _mediator.ExecuteAsync(request).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.OK, updatedMatch);
        }

        [Admin]
        [HttpPut]
        [Route("api/matches/{id}/updateWinner")]
        public async Task<MatchDto> UpdateWinner([FromUri]int id, [FromBody] MatchDto match)
        {
            match.Id = id;
            var request = new UpdateWinnerRequest
            {
                Match = match
            };
            return await _mediator.ExecuteAsync(request).ConfigureAwait(false);
        }

        [Admin]
        [HttpPut]
        [Route("api/matches/{id}/cancelMatch")]
        public async Task<HttpResponseMessage> CancelMatch([FromUri]int id)
        {
            var request = new CancelMatchRequest
            {
                Id = id
            };
            await _mediator.ExecuteAsync(request).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.OK);
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

        [Admin]
        [HttpGet]
        [Route("api/matches/pendingPastMatches")]
        public async Task<IEnumerable<MatchDto>> pendingPastMatches([FromUri]RequestParamsDto reqParams)
        {
            var request = new PendingPastMatchesRequest()
            {
                RequestParams = reqParams
            };
            return await _mediator.ExecuteAsync(request).ConfigureAwait(false);
        }

        [Auth]
        [HttpGet]
        public async Task<MatchDto> GetMatch([FromUri] int id)
        {
            var request = new GetMatchRequest()
            {
                Id = id
            };
            return await _mediator.ExecuteAsync(request).ConfigureAwait(false);
        }

        [Admin]
        [HttpDelete]
        public async Task DeleteMatch([FromUri] int id)
        {
            var request = new DeleteMatchRequest()
            {
                MatchId = id
            };
            await _mediator.ExecuteAsync(request).ConfigureAwait(false);
        }

        [Auth]
        [HttpPost]
        [Route("api/matches/{matchId}/predictions")]
        public async Task<HttpResponseMessage> CreatePrediction([FromUri]int matchId, [FromBody] PredictionDto prediction)
        {
            prediction.MatchId = matchId;
            var request = new CreatePredictionRequest()
            {
                Prediction = prediction
            };

            await _mediator.ExecuteAsync(request).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [Auth]
        [HttpPut]
        [Route("api/matches/{matchId}/predictions/{predictionId}")]
        public async Task<HttpResponseMessage> UpdatePrediction([FromUri]int matchId, [FromUri] int predictionId, [FromBody] PredictionDto prediction)
        {
            prediction.MatchId = matchId;
            prediction.Id = predictionId;
            var request = new UpdatePredictionRequest()
            {
                Prediction = prediction
            };

            await _mediator.ExecuteAsync(request).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Auth]
        [HttpDelete]
        [Route("api/matches/{matchId}/predictions/{predictionId}")]
        public async Task DeletePrediction([FromUri]int matchId, [FromUri] int predictionId)
        {
            var request = new DeletePredictionRequest()
            {
                PredictionId = predictionId
            };

            await _mediator.ExecuteAsync(request).ConfigureAwait(false);
        }
    }
}

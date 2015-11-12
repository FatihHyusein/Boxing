using Boxing.Models;
using Boxing.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Boxing.Controllers
{
    public class MatchesController : ApiController
    {
        [HttpGet]
        [AuthorizationFilter]
        public async Task<IEnumerable<Match>> GetAll()
        {
            return new List<Match>();
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Create(Match match)
        {
            return Request.CreateResponse(HttpStatusCode.Created, new Match());
        }

        [HttpPut]
        public async Task<Match> WriteWinner(string matchId)
        {
            return new Match();
        }

        [HttpPost]
        [AuthorizationFilter]
        [Route("api/matches/{matchId}/predictions")]
        public async Task<HttpResponseMessage> CreatePrediction(string matchId)
        {
            return Request.CreateResponse(HttpStatusCode.Created, new Match());
        }
    }
}

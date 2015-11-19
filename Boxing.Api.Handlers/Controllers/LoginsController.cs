using Boxing.Api.Handlers.Filters;
using Boxing.Contracts;
using Boxing.Contracts.Dto;
using Boxing.Contracts.Requests.Logins;
using Boxing.Core.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Boxing.Api.Handlers.Controllers
{
    public class LoginsController : ApiController
    {
        private readonly IMediator _mediator;
        private string _authToken;

        public LoginsController(IMediator mediator)
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

        [HttpPost]
        public async Task<HttpResponseMessage> Create([FromBody] LoginDto login)
        {
            var request = new CreateLoginRequest()
            {
                User = login
            };

            UserDto loggedUser = await _mediator.ExecuteAsync(request).ConfigureAwait(false);
            return Request.CreateResponse(System.Net.HttpStatusCode.Created, new { id=loggedUser.Id, authToken = loggedUser.AuthToken});
        }

        [Auth]
        [HttpDelete]
        public async Task Delete(string id)
        {
            var request = new DeleteLoginRequest()
            {
                Id = id
            };
            
            await _mediator.ExecuteAsync(request).ConfigureAwait(false);
        }

    }
}
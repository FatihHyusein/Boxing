﻿using Boxing.Api.Handlers.Filters;
using Boxing.Contracts;
using Boxing.Contracts.Dto;
using Boxing.Contracts.Requests.Users;
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
    public class UsersController : ApiController
    {
        private readonly IMediator _mediator;
        private string _authToken;

        public UsersController(IMediator mediator)
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
        public async Task<HttpResponseMessage> Create([FromBody] UserDto User)
        {
            var request = new CreateUserRequest()
            {
                User = User
            };

            UserDto registeredUser = await _mediator.ExecuteAsync(request).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.Created, new { Id = registeredUser.Id, rating = registeredUser.Rating });
        }

        [Auth]
        [HttpPut]
        public async Task<HttpResponseMessage> Update([FromUri] int id, [FromBody] UserDto User)
        {
            User.Id = id;
            var request = new UpdateUserRequest()
            {
                User = User
            };

            UserDto updatedUser = await _mediator.ExecuteAsync(request).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.OK, updatedUser);
        }

        [Auth]
        [HttpGet]
        public async Task<IEnumerable<UserPreviewDto>> Get([FromUri]RequestParamsDto reqParams)
        {
            var request = new GetAllUsersRequest()
            {
                RequestParams = reqParams
            };

            return await _mediator.ExecuteAsync(request).ConfigureAwait(false);
        }

        [HttpGet]
        public async Task<UserPreviewDto> GetUser([FromUri] int id)
        {
            var request = new GetUserRequest()
            {
                Id = id
            };
            return await _mediator.ExecuteAsync(request).ConfigureAwait(false);
        }

        [Admin]
        [HttpDelete]
        public async Task DeleteUser([FromUri] int id)
        {
            var request = new DeleteUserRequest()
            {
                UserId = id
            };
            await _mediator.ExecuteAsync(request).ConfigureAwait(false);
        }
    }
}

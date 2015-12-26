using Boxing.Contracts;
using Boxing.Core.Sql;
using Boxing.Core.Sql.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Boxing.Api.Handlers.Filters
{
    public class AuthAttribute : AuthorizationFilterAttribute
    {
        private readonly BoxingContext _db;

        public AuthAttribute()
        {
            _db = new BoxingContext();
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var headers = actionContext.Request.Headers;
            IEnumerable<string> values;
            var token = string.Empty;
            if (headers.TryGetValues(Constants.Headers.AuthTokenHeader, out values))
                token = values.FirstOrDefault();

            var tokenFromDb = _db.Users.Where(t => t.AuthToken == token).FirstOrDefault();

            if (tokenFromDb == null || token.Length < 1)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }

            var loggedUser = _db.Users.Where(t => t.AuthToken == token).FirstOrDefault();
            if (loggedUser != null)
            {
                Constants.Headers.CurrentUserId = loggedUser.Id;
            }

            base.OnAuthorization(actionContext);
        }
    }
}
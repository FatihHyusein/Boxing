﻿using Boxing.Contracts;
using Boxing.Core.Sql;
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
    public class AdminAttribute : ActionFilterAttribute
    {
        private readonly BoxingContext _db;

        public AdminAttribute()
        {
            _db = new BoxingContext();
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var tokenValue = actionContext.Request.Headers.FirstOrDefault(t => t.Key == Constants.Headers.AdminToken).Value;

            var token = "";
            if (tokenValue != null)
            {
                token = tokenValue.FirstOrDefault();
            }

            if (token != "securetoken")
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }

            Constants.Headers.CurrentUserId = (_db.Users.Where(t => t.AuthToken == token).FirstOrDefault()).Id;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace Boxing.Api.Handlers.Filters
{
    public class ExceptionsAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is ArgumentNullException)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.NotFound, new HttpError(actionExecutedContext.Exception.Message));
            }

            else if(actionExecutedContext.Exception is ArgumentException)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.BadRequest, new HttpError(actionExecutedContext.Exception.Message));
            }
        }
    }
}
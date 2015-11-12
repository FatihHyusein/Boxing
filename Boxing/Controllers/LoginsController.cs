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
    public class LoginsController : ApiController
    {
        public struct Login
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Create(Login user)
        {
            return Request.CreateResponse(System.Net.HttpStatusCode.Created,
                new
                {
                    id = 1,
                    authToken = "token"
                });
        }

        [HttpDelete]
        [AuthorizationFilter]
        public async Task Delete(string id)
        {
            
        }
    }
}

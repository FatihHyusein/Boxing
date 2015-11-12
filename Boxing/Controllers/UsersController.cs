using Boxing.Models;
using Boxing.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Boxing.Controllers
{
    public class UsersController : ApiController
    {
        [HttpGet]
        [AuthorizationFilter]
        public async Task<IEnumerable<User>> GetAll()
        {
            return new List<User>();
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetById(string userId)
        {
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, new
            {
                username = "ddd"
            });
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Create(User user)
        {
            return Request.CreateResponse(System.Net.HttpStatusCode.Created,
                new
                {
                    userId = 1,
                    rating = 0
                });
        }
    }
}
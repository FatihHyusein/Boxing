using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Contracts.Requests.Logins
{
    public class DeleteLoginRequest : IRequest
    {
        public string Id { get; set; }
    }
}

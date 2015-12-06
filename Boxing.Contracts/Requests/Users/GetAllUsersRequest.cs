using Boxing.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Contracts.Requests.Users
{
    public class GetAllUsersRequest : IRequest<IEnumerable<UserPreviewDto>>
    {
        public RequestParamsDto RequestParams { get; set; }
    }
}

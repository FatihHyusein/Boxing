using Boxing.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Contracts.Requests.Matches
{
    public class GetAllMatchesRequest : IRequest<IEnumerable<MatchDto>>
    {
        public RequestParamsDto RequestParams { get; set; }
    }
}

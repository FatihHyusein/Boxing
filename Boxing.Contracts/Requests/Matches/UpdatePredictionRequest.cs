using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Contracts.Requests.Matches
{
    public class UpdatePredictionRequest : IRequest
    {
        public string MatchID { get; set; }
        public string PredictionId { get; set; }
    }
}

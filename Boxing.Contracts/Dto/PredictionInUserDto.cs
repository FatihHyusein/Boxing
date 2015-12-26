using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Contracts.Dto
{
    public class PredictionInUserDto
    {
        public int Id { get; set; }
        public MatchInUserDto Match { get; set; }
        public int MatchId { get; set; }
        public int UserId { get; set; }
        public string Winner { get; set; }
        public bool IsClosedMatch { get; set; }
    }
}

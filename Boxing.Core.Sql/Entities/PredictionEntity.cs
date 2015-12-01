using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Core.Sql.Entities
{
    public class PredictionEntity
    {
        public int Id { get; set; }
        public string Winner { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public int MatchId { get; set; }
        public MatchEntity Match { get; set; }
    }
}

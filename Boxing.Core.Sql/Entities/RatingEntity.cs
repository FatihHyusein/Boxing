using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Core.Sql.Entities
{
    public class RatingEntity
    {
        public int Id { get; set; }
        public int TotalPredictions { get; set; }
        public int WrongPredictionsCount { get; set; }
        public int CorrectPredictionsCount { get; set; }
        public int Rating { get; set; }
    }
}

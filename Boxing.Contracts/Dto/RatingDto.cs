using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Contracts.Dto
{
    public class RatingDto
    {
        public int Id { get; set; }
        public int TotalPredictions { get; set; }
        public int WrongPredictionsCount { get; set; }
        public int CorrectPredictionsCount { get; set; }
        public int Rating { get; set; }

        public string CorrectPredictionsPercent
        {
            get
            {
                float valueAsFloat = (this.TotalPredictions > 0) ? (((float)this.CorrectPredictionsCount / (float)this.TotalPredictions)) : 0;
                return String.Format("{0:P2}", valueAsFloat);
            }
        }
    }
}

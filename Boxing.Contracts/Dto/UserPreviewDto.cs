using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Contracts.Dto
{
    public class UserPreviewDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public RatingDto Rating { get; set; }

        public ICollection<GetPredictionDto> Predictions { get; set; }
    }
}

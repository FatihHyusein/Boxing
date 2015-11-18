using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boxing.Models
{
    public enum PredictionValue
    {
        First,
        Equal,
        Second
    }
    public class Prediction
    {
        public int Id;
        [Required]
        public string UserId { get; set; }
        public User User { get; set; }
        [Required]
        public string MatchId { get; set; }
        public Match Match { get; set; }
        [Required]
        public PredictionValue value { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Boxing.Models
{
    public class Match
    {
        public int Id { get; set; }
        [Required]
        public string FirstBoxer { get; set; }
        [Required]
        public string SecondBoxer { get; set; }
        public string Location { get; set; }
        [Required]
        public DateTime BoxingDate { get; set; }
        public string Description { get; set; }
        public List<Prediction> Predictions{ get; set; }
    }
}
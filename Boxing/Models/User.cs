using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Boxing.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        public string FullName { get; set; }
        [Required]
        public string Password { get; set; }
        //public List<Prediction> Predictions { get; set; }
    }
}
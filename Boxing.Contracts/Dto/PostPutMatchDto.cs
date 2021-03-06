﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Contracts.Dto
{
    public class PostPutMatchDto
    {        public int Id { get; set; }
        public string Boxer1 { get; set; }
        public string Boxer2 { get; set; }
        public string Place { get; set; }
        public DateTime DateOfMatch { get; set; }
        public string Dsecription { get; set; }
        public ICollection<PredictionDto> Predictions { get; set; }
        public PredictionDto CurrentPrediction { get; set; }
    }
}

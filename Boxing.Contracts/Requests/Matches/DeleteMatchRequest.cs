﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Contracts.Requests.Matches
{
    public class DeleteMatchRequest :IRequest
    {
        public int MatchId { get; set; }
    }
}
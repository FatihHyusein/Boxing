﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Contracts.Requests.Users
{
    public class DeleteUserRequest : IRequest
    {
        public string UserId { get; set; }
    }
}

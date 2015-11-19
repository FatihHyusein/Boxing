﻿using Boxing.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Contracts.Requests.Logins
{
    public class CreateLoginRequest : IRequest<UserDto>
    {
        public LoginDto User { get; set; }
    }
}

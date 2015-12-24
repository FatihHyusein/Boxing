using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Contracts
{
    public static class Constants
    {
        public static class Headers
        {
            public static string AuthTokenHeader = "Auth-Token";
            public static string AdminToken = "admin-token";
            public static int CurrentUserId { get; set; }
        }
    }
}

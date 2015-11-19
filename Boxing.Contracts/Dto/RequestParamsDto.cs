using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Contracts.Dto
{
    public class RequestParamsDto
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public string SortBy { get; set; }
        public bool Asc { get; set; }
    }
}

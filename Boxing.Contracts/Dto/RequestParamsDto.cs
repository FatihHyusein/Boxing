using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing.Contracts.Dto
{
    public class RequestParamsDto
    {
        private int take;

        public int Skip { get; set; }
        public string Sort { get; set; }

        public int Take
        {
            get
            {
                return this.take;
            }
            set
            {
                this.take = (value > 0) ? value : 20;
            }
        }
        public string SortingOrder
        {
            get
            {
                if (this.Sort == null)
                {
                    return "ASC";
                }
                else
                {
                    return (this.Sort[0] == '-') ? "ASC" : "DESC";
                }
            }
        }
        public string SortBy
        {
            get
            {
                if (this.Sort == null)
                {
                    return null;
                }
                else
                {
                    return (this.Sort[0] == '-') ? this.Sort.Substring(1) : this.Sort;
                }
            }
        }
    }
}

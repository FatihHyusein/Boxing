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
        private string search;
        private DateTime searchedDate;

        public int Skip { get; set; }
        public string Sort { get; set; }

        public string Search
        {
            get
            {
                return this.search;
            }
            set
            {
                this.search = (value == null) ? string.Empty : value;
            }
        }

        public DateTime SearchedDate
        {
            get
            {
                DateTime.TryParse(this.Search, out searchedDate);
                return this.searchedDate;
            }
        }

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

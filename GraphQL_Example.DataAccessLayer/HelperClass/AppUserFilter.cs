using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL_Example.DataAccessLayer.HelperClass
{
    public class AppUserFilter
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public string Search { get; set; } = "";
        public string SortBy { get; set; } = "name";
    }
}

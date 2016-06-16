using System.Collections.Generic;
using Nightscout.Controllers;

namespace Nightscout.Models
{
    public class QueryFilter
    {
        public QueryFilter()
        {
            Filters = new List<QueryItem>();
        }

        public List<QueryItem> Filters { get; private set; }
    }
}
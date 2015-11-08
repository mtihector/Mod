using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mod.Core.Cqrs.Api;

namespace Mod.Core.Test.Query.MockQuery
{
    public class QueryB: IQuery
    {
        public DateTime FromSearch { get; }

        public QueryB(DateTime fromSearch)
        {
            FromSearch = fromSearch;
        }
    }
}

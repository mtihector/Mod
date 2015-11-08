using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mod.Core.Cqrs.Api;

namespace Mod.Core.Test.Query.MockQuery
{
    public class QueryA : IQuery
    {
        public string StringToSearch { get; }

        public QueryA(string stringToSearch)
        {
            StringToSearch = stringToSearch;
        }
    }
}

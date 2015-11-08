using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mod.Core.Cqrs.Api;

namespace Mod.Core.Test.Query.MockQuery
{
    public class QueryHandlerA: IQueryHandler<QueryA>
    {
        public object Handle(QueryA query)
        {
            return new TestValueObject("Hector","MX");
        }
    }
}

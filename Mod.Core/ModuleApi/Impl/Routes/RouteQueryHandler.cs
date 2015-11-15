using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mod.Core.Cqrs.Api;
using Mod.Core.ModuleApi.Impl.Routes.Dto;

namespace Mod.Core.ModuleApi.Impl.Routes
{
    public  class RouteQueryHandler : IQueryHandler<RouteQuery>
    {
        public object Handle(RouteQuery query)
        {
            return new List<RouteDto>()
            {
                new RouteDto("Security/Users", "Security/Users/Users"),
                new RouteDto("Security/Security", "Security/Users/Security")
            };
        }
    }
}

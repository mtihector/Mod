using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mod.Core.Cqrs.Api;
using Mod.Core.ModuleApi.Impl.Routes.Dto;
using Mod.Core.ModuleApi.Routes;

namespace Mod.Core.ModuleApi.Impl.Routes
{
    public  class RouteQueryHandler : IQueryHandler<RouteQuery>
    {
        private readonly IRouteService _routeService;
        public RouteQueryHandler(IRouteService routeService)
        {
            _routeService = routeService;
        }

        public object Handle(RouteQuery query)
        {
            return _routeService.GetRoutes().Select(c => new RouteDto(c.Route, c.Controller)).ToList();
            
        }
    }
}

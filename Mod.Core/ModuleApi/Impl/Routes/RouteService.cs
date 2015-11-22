using System.Collections.Generic;
using Mod.Core.ModuleApi.Routes;

namespace Mod.Core.ModuleApi.Impl.Routes
{
    public class RouteService : IRouteService
    {
        private readonly List<RouteItem> _routes ;

        public RouteService()
        {   _routes = new List<RouteItem>();
        }

        public void RegisterRoute(List<RouteItem> routeItems)
        {
            _routes.AddRange(routeItems);
        }

        public void RegisterRoute(RouteItem routeItem)
        {
            _routes.Add(routeItem);
        }

        public List<RouteItem> GetRoutes()
        {
            return _routes;
        }
    }
}

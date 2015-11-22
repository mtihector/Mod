using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod.Core.ModuleApi.Routes
{
    public interface IRouteService
    {
        void RegisterRoute(RouteItem routeItem);
        void RegisterRoute(List<RouteItem> routeItems);
        List<RouteItem> GetRoutes();
    }
}

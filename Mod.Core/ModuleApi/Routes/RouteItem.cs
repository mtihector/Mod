using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mod.Core.ModuleApi.Menu;

namespace Mod.Core.ModuleApi.Routes
{
    public class RouteItem
    {
        public string Route { get; }
        public string Controller { get; }
        List<Role>  Roles { get; }


        public RouteItem(string route, string controller, List<Role> roles )
        {
            Route = route;
            Controller = controller;
            Roles = roles;
        }
    }
}

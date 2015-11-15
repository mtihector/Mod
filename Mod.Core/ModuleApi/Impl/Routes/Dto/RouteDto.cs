using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod.Core.ModuleApi.Impl.Routes.Dto
{
    public class RouteDto
    {
        public string Route { get; }
        public string Controller { get; }

        public RouteDto(string route, string controller)
        {
            Route = route;
            Controller = controller;
        }
    }
}

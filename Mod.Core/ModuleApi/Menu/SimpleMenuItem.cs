using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod.Core.ModuleApi.Menu
{
    public class SimpleMenuItem : IMenuItem
    {
        public string MenuItemName { get; }
        public string ModuleBelongs { get; }
        public string MenuPath { get; }
        public string Route { get; }
        public ICollection<Role> Roles { get; }
        

        public SimpleMenuItem(string menuItemName, string moduleBelongs, string menuPath, string route, ICollection<Role> roles)
        {
            MenuItemName = menuItemName;
            ModuleBelongs = moduleBelongs;
            MenuPath = menuPath;
            Roles = roles;
            Route = route;

        }
    }
}

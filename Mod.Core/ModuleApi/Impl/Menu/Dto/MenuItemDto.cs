using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod.Core.ModuleApi.Impl.Menu.Dto
{
    public class MenuItemDto
    {
        public string MenuItemName { get; }
        public string ModuleBelongs { get; }
        public string MenuPath { get; }
        public string Route { get; }

        public MenuItemDto(string menuItemName, string moduleBelongs, string menuPath, string route)
        {
            MenuItemName = menuItemName;
            ModuleBelongs = moduleBelongs;
            MenuPath = menuPath;
            Route = route;
        }
    }
}

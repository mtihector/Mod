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
        public string Path { get; }
        public ICollection<Role> Roles { get; }
        public string ModuleEntryPoint { get; }

        public SimpleMenuItem(string menuItemName, string moduleBelongs, string path, ICollection<Role> roles, string moduleEntryPoint)
        {
            MenuItemName = menuItemName;
            ModuleBelongs = moduleBelongs;
            Path = path;
            Roles = roles;
            ModuleEntryPoint = moduleEntryPoint;
        }
    }
}

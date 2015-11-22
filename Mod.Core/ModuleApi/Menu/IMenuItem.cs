using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod.Core.ModuleApi.Menu
{
    public interface IMenuItem
    {
        string MenuItemName { get; }
        string ModuleBelongs { get; }
        string MenuPath { get; }
        string Route { get; }
        
    }
}

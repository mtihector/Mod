using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mod.Core.ModuleApi.Menu;

namespace Mod.Core.ModuleApi.Impl
{
    public class MenuService : IMenuService
    {
        public List<IMenuItem> MenuItems { get; }

        public MenuService()
        {
            MenuItems = new List<IMenuItem>();
        }

        public void RegisterMenu(ICollection<IMenuItemSecure> menuItems)
        {
            MenuItems.AddRange(menuItems);
        }


        public ICollection<IMenuItem> GetMenuCurrentUser()
        {
            //TODO: Add role permissions
            return MenuItems;
        }
    }
}

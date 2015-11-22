using System.Collections.Generic;

namespace Mod.Core.ModuleApi.Menu
{
    public  interface IMenuService
    {
        void RegisterMenu(ICollection<IMenuItemSecure> menuItems);
        ICollection<IMenuItem> GetMenuCurrentUser();
    }
}

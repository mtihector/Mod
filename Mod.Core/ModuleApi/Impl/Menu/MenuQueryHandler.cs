using System.Collections.Generic;
using System.Linq;
using Mod.Core.Cqrs.Api;
using Mod.Core.ModuleApi.Impl.Menu.Dto;
using Mod.Core.ModuleApi.Menu;

namespace Mod.Core.ModuleApi.Impl.Menu
{
    public class MenuQueryHandler : IQueryHandler<MenuQuery>
    {

        private IMenuService _menuService;

        public MenuQueryHandler(IMenuService menuService)
        {
            _menuService = menuService;
        }


        public object Handle(MenuQuery query)
        {
            return
                _menuService.GetMenuCurrentUser().OrderBy(c=> c.MenuPath)
                    .Select(c => new MenuItemDto(c.MenuItemName, c.ModuleBelongs, c.MenuPath, c.Route)).ToList();
           
        }
    }
}

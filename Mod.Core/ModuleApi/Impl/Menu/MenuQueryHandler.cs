using System.Collections.Generic;
using Mod.Core.Cqrs.Api;
using Mod.Core.ModuleApi.Menu;

namespace Mod.Core.ModuleApi.Impl.Menu
{
    public class MenuQueryHandler : IQueryHandler<MenuQuery>
    {
        public object Handle(MenuQuery query)
        {
            List<IMenuItem> items = new List<IMenuItem>();
            items.Add(new SimpleMenuItem("Users","Security","Security","/Security/Users",new List<Role>() ));
            items.Add(new SimpleMenuItem("Security", "Security", "Security", "/Security/Security", new List<Role>()));
            items.Add(new SimpleMenuItem("Security Map", "Security", "Security", "/Security/SecurityMap", new List<Role>()));


            
            items.Add(new SimpleMenuItem("View Tickets", "Tickets", "Tickets", "/Tickets/View", new List<Role>()));
            items.Add(new SimpleMenuItem("Dashboard", "Tickets", "Tickets", "/Tickets/Dashboard", new List<Role>()));

            return items;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mod.Core.Cqrs.Api;
using Mod.Core.ModuleApi.Menu;

namespace Mod.Core.ModuleApi.Impl
{
    public class MenuQueryHandler : IQueryHandler<MenuQuery>
    {
        public object Handle(MenuQuery query)
        {
            List<IMenuItem> items = new List<IMenuItem>();
            items.Add(new SimpleMenuItem("Users","Security","Security",new List<Role>(),"Users" ));
            items.Add(new SimpleMenuItem("Permissions", "Security", "Security", new List<Role>(), "Users"));
            items.Add(new SimpleMenuItem("Security Map", "Security", "Security", new List<Role>(), "Users"));


            
            items.Add(new SimpleMenuItem("View Tickets", "Tickets", "Tickets", new List<Role>(), "tickets"));
            items.Add(new SimpleMenuItem("Dashboard", "Tickets", "Tickets", new List<Role>(), "tickets"));

            return items;
        }
    }
}

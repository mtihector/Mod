using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mod.Core.Cqrs;
using Mod.Core.ModuleApi.Impl.Menu;
using Mod.Core.ModuleApi.Impl.Routes;
using Mod.Core.ModuleApi.Menu;
using Mod.Core.ModuleApi.Routes;
using SimpleInjector;

namespace Mod.Core.Infraestructure
{

    public class InfrastructureConfig
    {
        private readonly Container _container;

        public InfrastructureConfig(Container container)
        {
            _container = container;

        }

        public void RegisterTypes()
        {
            _container.Register<IMenuService, MenuService>(Lifestyle.Singleton);
            _container.Register<IRouteService, RouteService>(Lifestyle.Singleton);
            _container.RegisterSingleton(GetCommandBus);
            _container.RegisterSingleton(GetQueryBus);
        }

        private ICommandBusService GetCommandBus()
        {
            ICommandBusService cbus = new CommandBusService(_container);

            return cbus;
        }

        private IQueryBusService GetQueryBus()
        {
            QueryBusService qbus = new QueryBusService(_container);
            qbus.RegisterQueryHandler<MenuQuery, MenuQueryHandler>();
            qbus.RegisterQueryHandler<RouteQuery, RouteQueryHandler>();
            return qbus;
        }
    }
}

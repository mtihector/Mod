using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using Mod.Core.Infraestructure.Log;
using Mod.Core.ModuleApi;
using Mod.Core.ModuleApi.Menu;
using Mod.Core.ModuleApi.Routes;
using SimpleInjector;

namespace Mod.Core.ModuleA
{
    public class ModuleActivator :IModuleActivator
    {
      

        public void RegisterConfigurations(Container container)
        {
            
        }

        public void StartModule(Container container)
        {
            ILog log = LogUtils.GetLog(this);
            log.Debug("Starting Module Demo");
            
            
            
            log.Debug("Registering menu item");

            container.GetInstance<IMenuService>().RegisterMenu(new List<IMenuItemSecure>()
            {
                new SimpleMenuItem("Demo Option", "ModuleA", "Module Demo", "ctrl/ModuleDemo/DemoOption",new List<Role>())
            });


            container.GetInstance<IRouteService>().RegisterRoute(new RouteItem("ctrl/ModuleDemo/DemoOption", "ModuleA/DemoController",new List<Role>()));

            log.Debug("Module Demo start completed");
        }

        public void StopModule()
        {
            ILog log = LogUtils.GetLog(this);
            log.Debug("Stopping Module Demo");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Mod.Core.Infraestructure.Log;
using Mod.Core.ModuleApi;
using Mod.Core.ModuleApi.Menu;
using Mod.Core.ModuleApi.Routes;
using SimpleInjector;

namespace Mod.Core.Security
{
    public class SecurityActivator : IModuleActivator
    {
        public void RegisterConfigurations(Container container)
        {
            ILog log = LogUtils.GetLog(this);
            log.Debug("Registering Container info");


            log.Debug("Register completed");

        }


        public void StartModule(Container container)
        {
            ILog log = LogUtils.GetLog(this);
            log.Debug("Starting Module");

            log.Debug("Registering routes");

            container.GetInstance<IRouteService>().RegisterRoute(new List<RouteItem>()
            {
                new RouteItem("ctrl/Security/Users", "Security/Users/Users", new List<Role>()),
                new RouteItem("ctrl/Security/Security", "Security/Users/Security", new List<Role>())
            });

            log.Debug("Registering Menu Options");

            container.GetInstance<IMenuService>().RegisterMenu(new Collection<IMenuItemSecure>()
            {
               new SimpleMenuItem("Users","Security","Security","ctrl/Security/Users",new List<Role>()),
               new SimpleMenuItem("Security","Security","Security","ctrl/Security/Security",new List<Role>()),
               new SimpleMenuItem("Security Map","Security","Security","ctrl/Security/SecurityMap",new List<Role>())
            });



            log.Debug("Module Started sucesfully");
        }

        public void StopModule()
        {
            ILog log = LogUtils.GetLog(this);
            log.Debug("Stopping module");

        }
    }
}

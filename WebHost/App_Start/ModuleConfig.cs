using log4net;
using log4net.Repository.Hierarchy;
using Mod.Core.Infraestructure.ModuleHandler;
using SimpleInjector;


namespace WebHost
{
    public static class ModuleConfig
    {
        private static ModuleLoader _moduleLoader;
        public static void RegisterComponents(Container container)
        {
            _moduleLoader= new ModuleLoader();
            container.RegisterSingleton(_moduleLoader);
            string path = System.Web.Hosting.HostingEnvironment.MapPath("~/pickupmodules");
            string deploy = System.Web.Hosting.HostingEnvironment.MapPath("~/deploy");
            _moduleLoader.Start(container, path, deploy);
        }


        public static void Stop()
        {
            ILog log = LogManager.GetLogger(typeof(ModuleConfig).FullName);
            log.Debug("Sending Stop Signal to module Loader");
            _moduleLoader?.Stop();
            log.Debug("Stop Signal sent to module Loader");
        }
    }
}
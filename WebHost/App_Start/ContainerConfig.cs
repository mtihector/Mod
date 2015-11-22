using System.Web.Http;
using log4net;
using Mod.Core.Cqrs;
using Mod.Core.Infraestructure;
using Mod.Core.ModuleApi.Impl;
using Mod.Core.ModuleApi.Impl.Menu;
using Mod.Core.ModuleApi.Impl.Routes;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace WebHost
{
    public static class ContainerConfig
    {
        public static void RegisterComponents()
        {
            ILog log = LogManager.GetLogger(typeof(ContainerConfig).FullName);
            log.Debug("Asignando SimpleInjector como DependencyResolver ");
            Container container = new Container();
            container.Options.AllowOverridingRegistrations = true;
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);


            //first Register all infrastrcutre types
            var config = new InfrastructureConfig(container);
            config.RegisterTypes();

            //then load and start modules
            //this will register types and then start the modules
            ModuleConfig.RegisterComponents(container);
        }
    }
}
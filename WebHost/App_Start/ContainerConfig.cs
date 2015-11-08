using System.Web.Http;
using log4net;
using Mod.Core.Cqrs;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace WebHost
{
    public static class ContainerConfig
    {

        //with simpleinjector
        public static void RegisterComponents()
        {
            ILog log = LogManager.GetLogger(typeof(ContainerConfig).FullName);
            log.Debug("Asignando SimpleInjector como DependencyResolver ");
            Container container = new Container();
            container.Options.AllowOverridingRegistrations = true;
            container.Register<ICommandBusService, CommandBusService>(Lifestyle.Singleton);
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            ModuleConfig.RegisterComponents(container); // <-- New Class
        }


        //with unity container
        // i started this using Unity but i want to try SimpleInjector
        //public static void RegisterComponents()
        //{
        //    var container = new UnityContainer();

        //    container.RegisterType<ICommandBusService, CommandBusService>(new ContainerControlledLifetimeManager());

        //    GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

        //    ModuleConfig.RegisterComponents(container);
        //}
    }
}
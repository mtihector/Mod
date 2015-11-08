using Microsoft.Practices.Unity;
using System.Web.Http;
using Mod.Core.Cqrs;


namespace WebHost
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<ICommandBusService, CommandBusService>(new ContainerControlledLifetimeManager());
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

            ModuleConfig.RegisterComponents(container);
        }
    }
}
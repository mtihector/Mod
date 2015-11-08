using SimpleInjector;

namespace Mod.Core.ModuleApi
{
    public interface IModuleActivator
    {
        void RegisterConfigurations(Container container);
        void StartModule(Container container);
        void StopModule();
    }
}

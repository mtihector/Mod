using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using Mod.Core.Infraestructure.Log;
using Mod.Core.ModuleApi;
using SimpleInjector;

namespace Mod.Core.ModuleA
{
    public class ModuleActivator :IModuleActivator
    {
        public Dictionary<Type, Type> GetConfiguration()
        {
            return null;
        }

        public void RegisterConfigurations(Container container)
        {
            
        }

        public void StartModule(Container container)
        {
            ILog log = LogUtils.GetLog(this);
            log.Debug("Starting Module Demo");
            ModelTest test = new ModelTest();
            int ev = test.Events.Count();
            //Logger.Write("Events : " + ev + " on Database", Categories.Verbose);
            log.Debug("Cambie algo aqui");
            log.Debug("Module Demo start completed");
        }

        public void StopModule()
        {
            ILog log = LogUtils.GetLog(this);
            log.Debug("Stopping Module Demo");
        }
    }
}

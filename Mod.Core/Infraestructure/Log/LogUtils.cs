using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Mod.Core.Infraestructure.Log
{
    public static class LogUtils
    {
        /// <summary>
        /// Get root log
        /// </summary>
        /// <returns></returns>
        public static ILog GetLog()
        {
            return LogManager.GetLogger("root");
        }

        public static ILog GetLog(Object obj)
        {
            return LogManager.GetLogger(obj.GetType().FullName);
        }

        public static ILog GetLog(Type type)
        {
            return LogManager.GetLogger(type.FullName);
        }
    }
}

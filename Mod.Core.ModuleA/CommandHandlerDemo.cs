
using log4net;
using log4net.Repository.Hierarchy;
using Mod.Core.Cqrs.Api;
using Mod.Core.Infraestructure.Log;


namespace Mod.Core.ModuleA
{
    public class CommandHandlerDemo : ICommandHandler<CommandDemo>
    {
       

        public void Handle(CommandDemo command)
        {
            ILog log = LogUtils.GetLog(this);
            log.Debug("Si se mando llamar");
        }
    }
}

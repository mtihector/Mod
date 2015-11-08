using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using log4net;
using Mod.Core.Cqrs.Api;
using SimpleInjector;

namespace Mod.Core.Cqrs
{
    public class CommandBusService : ICommandBusService
    {
        private readonly Guid _id;
        private Container _container;

        private Dictionary<Type, Type> _commands;

        public Guid Id
        {
            get { return _id; }
        }

        private ILog _log;
        public ILog Log => _log ?? (_log = LogManager.GetLogger(this.GetType().FullName));

        public CommandBusService(Container container)
        {
            Log.Debug("Constructing Command Bus Service");
            if (container == null)
            {
                Log.Error("Error while constructing CommandBusService The container cannot be null");
                throw new ArgumentNullException(nameof(container));
            }
            _container = container;
            _id = Guid.NewGuid();
            _commands = new Dictionary<Type, Type>();
            Log.Debug("Command Bus Service Constructed Successfully");
        }


        public void SendCommand<T>(T command) where T : ICommand
        {
            foreach (var item in _commands.Where(c => c.Key == typeof(T)).ToList())
            {
                var handler = (_container.GetInstance(item.Value) as ICommandHandler<T>);
                if (handler == null)
                {
                    string msg = "Command handler not found for command " + command.GetType().FullName;
                    Log.Error(msg);
                    throw new InstanceNotFoundException(msg);
                }
                handler.Handle(command);
            }
        }


        public void RegisterCommandHandler<T, TU>() where T : ICommand
            where TU : ICommandHandler<T>
        {
            RegisterCommandHandler(typeof(T), typeof(TU));
        }

        public void RegisterCommandHandler(Type command, Type commandHandler)
        {
            if (_commands.ContainsKey(command))
            {
                return;
            }
            _commands.Add(command, commandHandler);
        }
    }
}

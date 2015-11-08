using System;
using Mod.Core.Cqrs.Api;

namespace Mod.Core.Cqrs
{
    public interface ICommandBusService
    {
        Guid Id { get; }
        void SendCommand<T>(T command) where T : ICommand;

        void RegisterCommandHandler<T, TU>() where T : ICommand
            where TU : ICommandHandler<T>;

        void RegisterCommandHandler(Type command, Type commandHandler);

    }
}
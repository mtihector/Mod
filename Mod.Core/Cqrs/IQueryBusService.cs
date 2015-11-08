using System;
using Mod.Core.Cqrs.Api;

namespace Mod.Core.Cqrs
{
    public interface IQueryBusService
    {
        Guid Id { get; }

        object SendQuery<T>(T query) where T : IQuery;

        void RegisterQueryHandler<T, TU>() where T : IQuery where TU : IQueryHandler<T>;

        void RegisterQueryHandler(Type query, Type queryHandler);
    }
}

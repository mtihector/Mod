using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using log4net;
using Mod.Core.Cqrs.Api;
using SimpleInjector;

namespace Mod.Core.Cqrs
{
    public class QueryBusService : IQueryBusService
    {
        private readonly Guid _id;
        private Container _container;

        private Dictionary<Type, Type> _queries;

        public Guid Id
        {
            get { return _id; }
        }

        private ILog _log;
        public ILog Log => _log ?? (_log = LogManager.GetLogger(this.GetType().FullName));

        public QueryBusService(Container container)
        {
            Log.Debug("Constructing Query Bus Service");
            if (container == null)
            {
                Log.Error("Error while constructing Query The container cannot be null");
                throw new ArgumentNullException(nameof(container));
            }
            _container = container;
            _id = Guid.NewGuid();
            _queries = new Dictionary<Type, Type>();
            Log.Debug("Query Bus Service Constructed Successfully");
        }

        public object SendQuery<T>(T query) where T : IQuery
        {
            //Type of T must be explicit type will not work with IQuery
            //for callers that use reflection should be creating the objects in dynamic form
            //see Test DeserializeJsonToQuery in QueryBusTest.cs
            var item = _queries.FirstOrDefault(c => c.Key == typeof(T));
            var handler = (_container.GetInstance(item.Value) as IQueryHandler<T>);
            if (handler == null)
            {
                string msg = "Query handler not found for query " + query.GetType().FullName;
                Log.Error(msg);
                throw new InstanceNotFoundException(msg);
            }
            return handler.Handle(query);
        }

        public void RegisterQueryHandler<T, TU>() where T : IQuery where TU : IQueryHandler<T>
        {
            RegisterQueryHandler(typeof(T), typeof(TU));
        }

        public void RegisterQueryHandler(Type query, Type queryHandler)
        {
            if (_queries.ContainsKey(query))
            {
                return;
            }
            _queries.Add(query, queryHandler);
        }
    }
}

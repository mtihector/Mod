using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Formatters;
using System.Web.Http;
using Mod.Core.Cqrs;
using Mod.Core.Cqrs.Api;
using Newtonsoft.Json;

namespace WebHost.Controllers
{
    [Authorize]
    public class CqrsController : ApiController
    {
        private ICommandBusService _commandBus;
        private IQueryBusService _queryBusService;

        public CqrsController(ICommandBusService commandBusService, IQueryBusService queryBusService)
        {
            _commandBus = commandBusService;
            _queryBusService = queryBusService;
        }

        [HttpGet]
        public string Test()
        {
            return _commandBus.Id.ToString();
        }


        [HttpPost]
        public string SendCommand([FromBody]string command)
        {
            return _commandBus.Id.ToString();
        }

        [HttpPost]
        public object SendQuery([FromBody]string value)
        {
            //For explanation see Mod.Core.Test.Query.QueryBusTest.DeserializeJsonToQuery


            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Full
            };

            dynamic queryTmp = JsonConvert.DeserializeObject(value, settings);
            return _queryBusService.SendQuery(queryTmp);
        }
    }
}

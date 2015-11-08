using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mod.Core.Cqrs;

namespace WebHost.Controllers
{
    public class CqrsController : ApiController
    {
        private ICommandBusService _commandBus;

        public CqrsController(ICommandBusService commandBusService)
        {
            _commandBus = commandBusService;
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
    }
}

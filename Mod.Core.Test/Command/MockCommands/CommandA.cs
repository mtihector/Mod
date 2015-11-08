using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mod.Core.Cqrs.Api;

namespace Mod.Core.Test.Command.MockCommands
{
    public  class CommandA :ICommand
    {
        public string Nombre { get; set; } = "Demo Command A";
    }
}

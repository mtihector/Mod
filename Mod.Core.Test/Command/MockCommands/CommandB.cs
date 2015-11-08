using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mod.Core.Cqrs.Api;

namespace Mod.Core.Test.Command.MockCommands
{
    public class CommandB : ICommand
    {
        public string Name { get; set; } = "CommandB";

    }
}

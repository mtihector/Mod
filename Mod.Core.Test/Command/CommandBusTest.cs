using System;
using System.IO;
using log4net.Config;
using log4net.Repository.Hierarchy;
using Mod.Core.Cqrs;
using Mod.Core.Test.Command.MockCommands;
using NUnit.Framework;
using SimpleInjector;

namespace Mod.Core.Test.Command
{
    [TestFixture]
    public class CommandBusTest
    {
        [SetUp]
        public void Init()
        {

            
            XmlConfigurator.Configure(new FileInfo("Log4Net.xml"));



        }


        [Test]
        public void TestRegisterCommands()
        {

            Container container = new Container();
            ICommandBusService commandBus = new CommandBusService(container);
            commandBus.RegisterCommandHandler<CommandA, CommandHandlerA>();
            commandBus.SendCommand(new CommandA());

        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateBusWithoutContainerTest()
        {
            ICommandBusService commandBus = new CommandBusService(null);

        }
    }
}

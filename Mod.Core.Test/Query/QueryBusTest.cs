using System;
using System.IO;
using System.Runtime.Serialization.Formatters;
using System.Security.Policy;
using log4net.Config;
using Mod.Core.Cqrs;
using Mod.Core.Cqrs.Api;
using Mod.Core.Test.Query.MockQuery;
using Newtonsoft.Json;
using NUnit.Framework;
using SimpleInjector;

namespace Mod.Core.Test.Query
{
    [TestFixture]
    public class QueryBusTest
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
            IQueryBusService queryBus = new QueryBusService(container);
            queryBus.RegisterQueryHandler<QueryA, QueryHandlerA>();
            var response = queryBus.SendQuery(new QueryA("Hector"));
            Assert.IsTrue(response != null);
        }

        [Test]
        public void DeserializeJsonToQuery()
        {
            Container container = new Container();
            IQueryBusService queryBus = new QueryBusService(container);
            queryBus.RegisterQueryHandler<QueryA, QueryHandlerA>();
            
            //this string will came from  a http POST through a web service
            string queryJson = "{ \"$type\":\"Mod.Core.Test.Query.MockQuery.QueryA, Mod.Core.Test, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = null\",\"StringToSearch\":\"Hector\"}";

            //The web service should deserialize the string and put it on dynamic
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Full
            };

            // We are using dynamics because the contravariant restrictions to convert a generic instance to less derived type 
            //  while using the generic type as a parameter for a method
            //see contravariant https://msdn.microsoft.com/en-us/library/dd469484%28v=vs.100%29.aspx
            //and covariant https://msdn.microsoft.com/en-us/library/dd469484%28v=vs.100%29.aspx


            //using the dynamic cheat, probably we can also call the method with reflection,
            //i'm not sure which options will be the 
            //best for performance
            dynamic queryTmp = JsonConvert.DeserializeObject(queryJson,settings);
            var response = queryBus.SendQuery(queryTmp);
            Assert.IsTrue(response != null);


        }

        [Test]
        public void SerializeToJsonObjectResponseInQuery()
        {
            Container container = new Container();
            IQueryBusService queryBus = new QueryBusService(container);
            queryBus.RegisterQueryHandler<QueryA, QueryHandlerA>();
            var response = queryBus.SendQuery(new QueryA("Hector"));
            Assert.IsTrue(response != null);

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Full
            };

            string json= JsonConvert.SerializeObject(response, settings);
            Assert.IsTrue(!String.IsNullOrEmpty(json));
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateBusWithoutContainerTest()
        {
            ICommandBusService commandBus = new CommandBusService(null);

        }
    }
}

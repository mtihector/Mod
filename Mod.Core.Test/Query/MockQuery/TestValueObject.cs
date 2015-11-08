using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod.Core.Test.Query.MockQuery
{
    public class TestValueObject
    {
        private string Name { get; }

        string Address { get; }

        public TestValueObject(string name, string address)
        {
            Name = name;
            Address = address;
        }
    }
}

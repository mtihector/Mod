using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod.Core.ModuleApi.Menu
{
    public class Role
    {
        public string ModuleName { get; }
        public string RoleName {get;}

        public Role(string moduleName, string roleName)
        {
            ModuleName = moduleName;
            RoleName = roleName;
        }
    }
}

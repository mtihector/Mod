using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod.Core.ModuleApi.Menu
{
    public interface  IMenuItemSecure : IMenuItem
    {
        ICollection<Role> Roles { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mod.Core.Cqrs.Api;

namespace Mod.Core.ModuleApi.Impl
{
    public class MenuQueryHandler : IQueryHandler<MenuQuery>
    {
        public object Handle(MenuQuery query)
        {
            throw new NotImplementedException();
        }
    }
}

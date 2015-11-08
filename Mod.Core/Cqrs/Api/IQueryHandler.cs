using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Mod.Core.Cqrs.Api
{
  

    public interface IQueryHandler<in T> where T : IQuery
    {
        object Handle(T query);
    }
}

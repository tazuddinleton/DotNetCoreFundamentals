using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.WebApi.Common.Types
{
    public interface IQuery
    {
    }

    public interface IQuery<T> : IQuery
    {
    }
}

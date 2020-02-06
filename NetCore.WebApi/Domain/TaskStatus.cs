using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.WebApi.Domain
{
    public enum TaskStatus
    {
        Pending = 1,
        Started = 2,
        Done = 3,
        Cancelled = 4
    }
   
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTaskManager.Data.Entities
{
    public enum TaskStatus
    {
        Pending = 1,
        Started = 2,
        Done = 3,
        Cancelled = 4,
        Postponed = 5
    }
}

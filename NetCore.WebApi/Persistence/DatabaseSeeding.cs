using NetCore.WebApi.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.WebApi.Persistence
{
    public static class DatabaseSeeding
    {
        public static void Seed()
        {
            using (var context = new DatabaseContext())
            {
                if (context.Tasks.Any())
                {

                    return;
                }

                context.Tasks.Add(new Domain.Task(Guid.NewGuid(), "Test1", "Test description 1", Guid.NewGuid(), DateTime.Now.AddDays(5), DateTime.Now.AddDays(20), null, null, Domain.TaskStatus.Pending, Domain.TaskPriority.Normal, null, Guid.NewGuid(), DateTime.Now));
                context.Tasks.Add(new Domain.Task(Guid.NewGuid(), "Test2", "Test description 2", Guid.NewGuid(), DateTime.Now.AddDays(5), DateTime.Now.AddDays(20), null, null, Domain.TaskStatus.Pending, Domain.TaskPriority.Normal, null, Guid.NewGuid(), DateTime.Now));
                context.Tasks.Add(new Domain.Task(Guid.NewGuid(), "Test3", "Test description 3", Guid.NewGuid(), DateTime.Now.AddDays(5), DateTime.Now.AddDays(20), null, null, Domain.TaskStatus.Pending, Domain.TaskPriority.Normal, null, Guid.NewGuid(), DateTime.Now));

                context.SaveChanges();
            }
        }
    }
}

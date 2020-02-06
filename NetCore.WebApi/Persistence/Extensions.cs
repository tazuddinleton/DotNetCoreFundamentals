using Autofac;
using Microsoft.EntityFrameworkCore;
using NetCore.WebApi.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.WebApi.Persistence
{
    public static class Extensions
    {
        public static void RegisterDbContext(this ContainerBuilder builder)
        {
            builder.RegisterType<DatabaseContext>()                
                .InstancePerLifetimeScope();
        }
    }
}

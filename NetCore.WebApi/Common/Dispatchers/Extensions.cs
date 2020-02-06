using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.WebApi.Common.Dispatchers
{
    public static class Extensions
    {
        public static void AddDispatchers(this ContainerBuilder builder)
        {
            builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>();
            builder.RegisterType<Dispatcher>().As<IDispatcher>();
            builder.RegisterType<QueryDispatcher>().As<IQueryDispatcher>();

        }
    }
}

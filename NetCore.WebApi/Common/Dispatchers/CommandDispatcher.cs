using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using NetCore.WebApi.Common.Handlers;
using NetCore.WebApi.Common.Messages;
using NetCore.WebApi.Common.RabbitMq;

namespace NetCore.WebApi.Common.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _context;

        public CommandDispatcher(IComponentContext context)
        {
            _context = context;
        }

        public Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            return _context.Resolve<ICommandHandler<TCommand>>().HandleAsync(command, CorrelationContext.Emtpy);
        }
    }
}

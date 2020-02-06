using NetCore.WebApi.Common.Messages;
using NetCore.WebApi.Common.RabbitMq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.WebApi.Common.Handlers
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command, ICorrelationContext context);
    }
}

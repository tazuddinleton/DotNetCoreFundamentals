using NetCore.WebApi.Common.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.WebApi.Common.RabbitMq
{
    public interface IBusPublisher
    {
        Task SendAsync<TCommand>(TCommand command, ICorrelationContext context)
            where TCommand : ICommand;

        Task PublishAsync<TEvent>(TEvent @event, ICorrelationContext context)
            where TEvent : IEvent;

    }
}

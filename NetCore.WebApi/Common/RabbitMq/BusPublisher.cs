using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCore.WebApi.Common.Messages;
using RabbitMQ;
namespace NetCore.WebApi.Common.RabbitMq
{
    public class BusPublisher : IBusPublisher
    {
        
        
        public BusPublisher()
        {
            
        }

        public Task PublishAsync<TEvent>(TEvent @event, ICorrelationContext context) where TEvent : IEvent
        {
            throw new NotImplementedException();
        }

        public Task SendAsync<TCommand>(TCommand command, ICorrelationContext context) where TCommand : ICommand
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.WebApi.Common.RabbitMq
{
    public class CorrelationContext : ICorrelationContext
    {
        public Guid Id => Id;

        public Guid UserId => UserId;

        public Guid ResourceId => ResourceId;

        public string TraceId => TraceId;

        public string SpanContext => SpanContext;

        public string ConnectionId => ConnectionId;

        public string Name => Name;

        public string Origin => Origin;

        public string Resource => Resource;

        public string Culture => Culture;

        public DateTime CreatedAt => CreatedAt;

        public int Retries => Retries;

        public static CorrelationContext Emtpy
            => new CorrelationContext();
    }
}

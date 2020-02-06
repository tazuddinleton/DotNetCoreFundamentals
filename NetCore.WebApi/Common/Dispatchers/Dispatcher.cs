using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCore.WebApi.Common.Messages;
using NetCore.WebApi.Common.Types;

namespace NetCore.WebApi.Common.Dispatchers
{
    public class Dispatcher : IDispatcher
    {
        ICommandDispatcher _commandDispatcher;
        IQueryDispatcher _queryDispatcher;


        public Dispatcher(ICommandDispatcher commandDispatcher,
            IQueryDispatcher queryDispatcher
            )
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
        {
            return await _queryDispatcher.QueryAsync(query);
        }

        public async Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            await _commandDispatcher.SendAsync(command);
        }
    }
}

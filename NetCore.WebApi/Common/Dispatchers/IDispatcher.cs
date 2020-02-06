using NetCore.WebApi.Common.Messages;
using NetCore.WebApi.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.WebApi.Common.Dispatchers
{
    public interface IDispatcher
    {
        Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand;

        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}

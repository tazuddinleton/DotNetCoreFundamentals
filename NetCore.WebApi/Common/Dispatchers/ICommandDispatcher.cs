using NetCore.WebApi.Common.Messages;
using System.Threading.Tasks;

namespace NetCore.WebApi.Common.Dispatchers
{
    public interface ICommandDispatcher
    {
        Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
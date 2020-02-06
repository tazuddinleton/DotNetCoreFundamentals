using NetCore.WebApi.Common.Types;
using System.Threading.Tasks;

namespace NetCore.WebApi.Common.Dispatchers
{
    public interface IQueryDispatcher
    {
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}
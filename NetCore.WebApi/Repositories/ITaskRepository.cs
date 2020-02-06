using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.WebApi.Repositories
{
    public interface ITaskRepository
    {
        Task AddAsync(Domain.Task task);
        Task UpdateAsync(Domain.Task task);

        Task<Domain.Task> FindByIdAsync(Guid id);
        Task<IQueryable<Domain.Task>> FindByAssigneeAsync(Guid id);
    }
}

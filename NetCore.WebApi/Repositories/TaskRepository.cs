using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using NetCore.WebApi;
using NetCore.WebApi.Domain;
using NetCore.WebApi.Persistence;

namespace NetCore.WebApi.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DatabaseContext _context;
        public TaskRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task AddAsync(Domain.Task task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }

        public System.Threading.Tasks.Task<IQueryable<Domain.Task>> FindByAssigneeAsync(Guid id)
        {
            return System.Threading.Tasks.Task.Run(() => _context.Tasks.Where(x => x.AssignedTo == id)); 
        }

        public System.Threading.Tasks.Task<Domain.Task> FindByIdAsync(Guid id)
        {
            return _context.Tasks.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async System.Threading.Tasks.Task UpdateAsync(Domain.Task task)
        {
            _context.Update(task);
            await _context.SaveChangesAsync();
        }        
    }
}

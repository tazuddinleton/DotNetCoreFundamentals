using Microsoft.EntityFrameworkCore;
using SimpleTaskManager.Data.Dtos;
using SimpleTaskManager.Data.Entities;
using SimpleTaskManager.Data.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTaskManager.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {

        private readonly TaskManagerContext _context;
        public TaskRepository(TaskManagerContext context)
        {
            _context = context;
        }
        public Task<int> AddAsync(TaskDto dto)
        {

            var task = Entities.Task.FromDto(dto);
            _context.Tasks.Add(task);
            return _context.SaveChangesAsync();
        }

        public Task<List<TaskDto>> GetAllAsync()
        {
            return _context.Tasks.Select(t => t.ToDto()).ToListAsync();
        }

        public async Task<TaskDto> GetByIdAsync(int id)
        {
            var entity = await _context.Tasks.FirstAsync(t => t.TaskId == id);
            return entity.ToDto();
        }
    }
}

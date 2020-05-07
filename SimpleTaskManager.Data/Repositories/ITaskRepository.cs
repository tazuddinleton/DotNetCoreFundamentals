using SimpleTaskManager.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTaskManager.Data.Repositories
{
    public interface ITaskRepository
    {
        Task<List<TaskDto>> GetAllAsync();        
        Task<int> AddAsync(TaskDto dto);
        Task<int> EditAsync(TaskDto dto);
        Task<TaskDto> GetByIdAsync(int id);
    }
}

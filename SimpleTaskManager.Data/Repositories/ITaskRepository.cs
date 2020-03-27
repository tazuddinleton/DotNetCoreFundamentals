using SimpleTaskManager.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTaskManager.Data.Repositories
{
    public interface ITaskRepository
    {
        Task<List<TaskDto>> GetAll();        
        Task<int> Add(TaskDto dto);
        Task<TaskDto> GetById(int id);
    }
}

using SimpleTaskManager.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTaskManager.Data.Entities
{
    public class Task
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CreatedById { get; set; }        
        public int? AssignedById { get; set; }
        public int? AssignedToId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdated { get; set; }

        public TaskStatus Status { get; set; }
        public TaskPriority Priority { get; set; }

        public static Task FromDto(TaskDto dto)
        {
            return new Task()
            {
                Title = dto.Title,
                Description = dto.Description,
                AssignedById = dto.AssignedById,
                AssignedToId = dto.AssignedToId,
                CreatedAt = DateTime.Now,
                CreatedById = dto.CreatedById,
                LastUpdated = DateTime.Now,
                Priority = dto.Priority,
                Status = dto.Status
            };
        }

        public TaskDto ToDto()
        {
            return new TaskDto()
            {
                Title = Title,
                Description = Description,
                AssignedById = (int)AssignedById,
                AssignedToId = (int)AssignedToId,
                CreatedAt = CreatedAt,
                CreatedById = CreatedById,
                LastUpdated = LastUpdated,
                Priority = Priority,
                Status = Status
            };
        }

    }
}

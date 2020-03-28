using SimpleTaskManager.Data.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimpleTaskManager.Data.Entities
{
    public class Task
    {
        public int TaskId { get; set; }
        [Required(ErrorMessage ="Please enter a title.")]
        public string Title { get; set; }

        [MaxLength(500, ErrorMessage ="Currently we are supporting 500 characters for description")]
        public string Description { get; set; }
        public int CreatedById { get; set; }        
        public int? AssignedById { get; set; }
        public int? AssignedToId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdated { get; set; }
        [Required]
        public TaskStatus Status { get; set; }
        [Required]
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
                TaskId = TaskId,
                Title = Title,
                Description = Description,
                AssignedById = AssignedById ?? null,
                AssignedToId = AssignedToId ?? null,
                CreatedAt = CreatedAt,
                CreatedById = CreatedById,
                LastUpdated = LastUpdated,
                Priority = Priority,
                Status = Status
            };
        }

    }
}

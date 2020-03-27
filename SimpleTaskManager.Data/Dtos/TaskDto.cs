using SimpleTaskManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTaskManager.Data.Dtos
{
    public class TaskDto
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CreatedById { get; set; }
        public string CreatedBy { get; set; }
        public int AssignedById { get; set; }
        public string AssignedBy { get; set; }  
        public int AssignedToId { get; set; }
        public string AssignedTo { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdated { get; set; }

        public TaskStatus Status { get; set; }
        public TaskPriority Priority { get; set; }
    }
}

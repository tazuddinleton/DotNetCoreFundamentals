
using NetCore.WebApi.Common.Messages;
using NetCore.WebApi.Domain;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace NetCore.WebApi.Messages.Commands
{

    public class CreateTaskCommand : ICommand
    {
        public Guid Id { get; }
        public string Title { get; }
        public string Description { get; }
        public Guid AssignedTo { get; }

        public DateTime PlannedStartDate { get; }
        public DateTime PlannedEndDate { get;  }

        public DateTime? ActualStartDate { get; }
        public DateTime? ActualEndDate { get; }

        public Domain.TaskStatus Status { get; }
        public TaskPriority Priority { get; }
        public string AttachmentPath { get; }

        public Guid Owner { get; }
        public DateTime EntryDate { get;}

        public CreateTaskCommand()
        { }

        [JsonConstructor]
        public CreateTaskCommand(Guid id, string title, string description, Guid assignedTo,DateTime plannedStartDate,
            DateTime plannedEndDate,DateTime? actualStartDate,DateTime? actualEndDate,Domain.TaskStatus status,
            TaskPriority priority, string attachmentPath, Guid owner, DateTime entryDate)
        {
            Id = id;
            Title = title;
            Description = description;
            AssignedTo = assignedTo;
            PlannedStartDate = plannedStartDate;
            PlannedEndDate = plannedEndDate;
            ActualStartDate = actualStartDate;
            ActualEndDate = ActualEndDate;
            Status = status;
            Priority = priority;
            AttachmentPath = attachmentPath;
            Owner = owner;
            EntryDate = entryDate;
        }
    }
}

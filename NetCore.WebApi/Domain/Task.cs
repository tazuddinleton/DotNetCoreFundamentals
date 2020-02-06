using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.WebApi.Domain
{
    public class Task
    {

        private string _name;
        public string Name => _name;
     

        private Guid _id;
        [Key]
        public Guid Id => _id;

        private string _title;
        public string Title => _title;

        private string _description;
        public string Description => _description;

        private Guid _assignedTo;
        public Guid AssignedTo => _assignedTo;

        private DateTime _plannedStartDate;
        public DateTime PlannedStartDate => _plannedStartDate;

        private DateTime _plannedEndDate;
        public DateTime PlannedEndDate => _plannedEndDate;

        private DateTime? _actualStartDate;
        public DateTime? ActualStartDate => _actualStartDate;

        private DateTime? _actualEndDate;
        public DateTime? ActualEndDate => _actualEndDate;

        private TaskStatus _status;
        public TaskStatus Status => _status;

        private TaskPriority _priority;
        public TaskPriority Priority => _priority;

        private string _attachmentPath;
        public string AttachmentPath => _attachmentPath;

        private Guid _owner;
        public Guid Owner => _owner;

        private DateTime _entryDate;
        public DateTime EntryDate => _entryDate;

        private Task() { }

        public Task(Guid id, string title)
        {
            this._id = id;
            this._title = title;
        }

        public Task(Guid id, string title, string description, Guid assignedTo, DateTime plannedStartDate,
                                 DateTime plannedEndDate, DateTime? actualStartDate, DateTime? actualEndDate,
                                 TaskStatus status, TaskPriority priority, string attachmentPath, Guid owner,
                                 DateTime entryDate)
        {
            this._id = id;
            this._title = title;
            this._description = description;
            this._assignedTo = assignedTo;
            this._plannedStartDate = plannedStartDate;
            this._plannedEndDate = plannedEndDate;
            this._actualStartDate = actualStartDate;
            this._actualEndDate = ActualEndDate;
            this._status = status;
            this._priority = priority;
            this._attachmentPath = attachmentPath;
            this._owner = owner;
            this._entryDate = entryDate;
        }
    }
}

using NetCore.WebApi.Common.Handlers;
using NetCore.WebApi.Common.RabbitMq;
using NetCore.WebApi.Messages.Commands;
using NetCore.WebApi.Messages.Events;
using NetCore.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.WebApi.Handlers
{
    public class CreateTaskCommandHandler : ICommandHandler<CreateTaskCommand>
    {

        private readonly IBusPublisher _publisher;
        private readonly ITaskRepository _taskRepository;
        public CreateTaskCommandHandler(ITaskRepository taskRepository,
            IBusPublisher publisher)
        {
            _publisher = publisher;
            _taskRepository = taskRepository;
        }

        public async Task HandleAsync(CreateTaskCommand command, ICorrelationContext context)
        {
            var task = new Domain.Task(command.Id, command.Title, command.Description, command.AssignedTo, command.PlannedStartDate, 
                    command.PlannedEndDate, command.ActualStartDate, command.ActualEndDate, command.Status, command.Priority, 
                    command.AttachmentPath, command.Owner, command.EntryDate);

            var taskCreated = new TaskCreatedEvent(command.Id, command.Title, command.Description, command.AssignedTo, command.PlannedStartDate,
                    command.PlannedEndDate, command.ActualStartDate, command.ActualEndDate, command.Status, command.Priority,
                    command.AttachmentPath, command.Owner, command.EntryDate);

            await _taskRepository.AddAsync(task);
            await _publisher.PublishAsync(taskCreated, context);

            // publish the event to bus
            // do some logging
        }
    }
}

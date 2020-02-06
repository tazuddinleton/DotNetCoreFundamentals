using NetCore.WebApi.Common.Handlers;
using NetCore.WebApi.Common.RabbitMq;
using NetCore.WebApi.Domain;
using NetCore.WebApi.Dto;
using NetCore.WebApi.Messages.Queries;
using NetCore.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.WebApi.Handlers
{
    public class GetTaskDetailQueryHandler : IQueryHandler<GetTaskDetailsQuery, TaskDetailDto>
    {
        private readonly IBusPublisher _publisher;
        private readonly ITaskRepository _taskRepository;

        public GetTaskDetailQueryHandler(ITaskRepository taskRepository)
        {   
            _taskRepository = taskRepository;
        }

        public async Task<TaskDetailDto> HandleAsync(GetTaskDetailsQuery query)
        {
            var task = await _taskRepository.FindByIdAsync(query.Id);
            if (task is null)
                return null;
            return new TaskDetailDto(task.Title);
        }


        public TaskDetailDto Handle(GetTaskDetailsQuery query)
        {
            return new TaskDetailDto(_taskRepository.FindByIdAsync(query.Id).Result.Title);
        }
    }
}

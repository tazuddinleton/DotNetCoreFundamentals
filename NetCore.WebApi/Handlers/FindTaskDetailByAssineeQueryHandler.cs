using NetCore.WebApi.Common.Handlers;
using NetCore.WebApi.Dto;
using NetCore.WebApi.Messages.Queries;
using NetCore.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.WebApi.Handlers
{
    public class FindTaskDetailByAssineeQueryHandler : IQueryHandler<FindTaskDetailByAssinee, IEnumerable<TaskDetailDto>>
    {

        private readonly ITaskRepository _taskRepository;
        public FindTaskDetailByAssineeQueryHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<IEnumerable<TaskDetailDto>> HandleAsync(FindTaskDetailByAssinee query)
        {
            var tasks = await _taskRepository.FindByAssigneeAsync(query.AssigneeId);
            // Good place to make a linq projection provided by automapper
            return tasks.Select(x => new TaskDetailDto(x.Title)).ToList();            
        }
    }
}

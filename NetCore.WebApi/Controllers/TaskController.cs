using Microsoft.AspNetCore.Mvc;
using NetCore.WebApi.Common.Dispatchers;
using NetCore.WebApi.Common.Mvc;
using NetCore.WebApi.Dto;
using NetCore.WebApi.Messages.Commands;
using NetCore.WebApi.Messages.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {

        private readonly IDispatcher _dispatcher;
        public TaskController(IDispatcher dispatcher)        
        {
            _dispatcher = dispatcher;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TaskDetailDto>> Get([FromRoute] GetTaskDetailsQuery query)
        {
            var taskDetail = await _dispatcher.QueryAsync(query);
            if (taskDetail == null)
                return NotFound();
            return taskDetail;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDetailDto>>> Get([FromQuery] FindTaskDetailByAssinee query)        
        {
            return Ok(await _dispatcher.QueryAsync(query));
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateTaskCommand command)
        {
            await _dispatcher.SendAsync(command.BindId(x => x.Id));
            return Accepted();
        }

    }
}

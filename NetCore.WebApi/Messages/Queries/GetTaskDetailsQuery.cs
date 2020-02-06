using NetCore.WebApi.Common.Types;
using NetCore.WebApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.WebApi.Messages.Queries
{
    public class GetTaskDetailsQuery : IQuery<TaskDetailDto>
    {
        public Guid Id { get; set; }
    }
}

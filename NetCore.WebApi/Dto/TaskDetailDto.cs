using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.WebApi.Dto
{
    public class TaskDetailDto
    {
        public string Title { get; }

        public TaskDetailDto(string title)
        {
            Title = title;
        }
    }
}

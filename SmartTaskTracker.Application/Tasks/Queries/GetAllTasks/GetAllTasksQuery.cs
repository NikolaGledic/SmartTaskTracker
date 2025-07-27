using MediatR;
using SmartTaskTracker.Application.Tasks.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTaskTracker.Application.Tasks.Queries.GetAllTasks
{
    public record GetAllTasksQuery : IRequest<List<TaskItemDto>>;
    
}

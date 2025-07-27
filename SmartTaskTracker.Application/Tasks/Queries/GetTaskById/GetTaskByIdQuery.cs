using MediatR;
using SmartTaskTracker.Application.Tasks.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTaskTracker.Application.Tasks.Queries.GetTaskById
{
    public record GetTaskByIdQuery(Guid Id) : IRequest<TaskItemDto?>;
    
}

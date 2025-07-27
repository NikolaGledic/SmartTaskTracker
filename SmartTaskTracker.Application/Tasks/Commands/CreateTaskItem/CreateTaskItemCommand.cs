using MediatR;
using SmartTaskTracker.Application.Tasks.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTaskTracker.Application.Tasks.Commands.CreateTaskItem
{
    public record CreateTaskItemCommand(
        string Title,
        string? Description,
        string Status,
        DateTime? Deadline,
        Guid? AssigneeId,
        Guid CreatorId
        ) : IRequest<TaskItemDto>;
    
}

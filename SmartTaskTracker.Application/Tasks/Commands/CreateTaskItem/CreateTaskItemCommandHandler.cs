using MediatR;
using SmartTaskTracker.Application.Tasks.DTOs;
using SmartTaskTracker.Core.Entities;
using SmartTaskTracker.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTaskTracker.Application.Tasks.Commands.CreateTaskItem
{
    public class CreateTaskItemCommandHandler : IRequestHandler<CreateTaskItemCommand, TaskItemDto>
    {
        private readonly SmartTaskTrackerDbContext _context;
        public CreateTaskItemCommandHandler(SmartTaskTrackerDbContext context) => _context = context;

        public async Task<TaskItemDto> Handle(CreateTaskItemCommand command, CancellationToken cancellationToken)
        {
            var task = new TaskItem
            {
                Id = Guid.NewGuid(),
                Title = command.Title,
                Description = command.Description,
                Status = command.Status,
                Deadline = command.Deadline,
                AssigneeId = command.AssigneeId,
                CreatorId = command.CreatorId,
                CreatedAt = DateTime.UtcNow,
            };
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync(cancellationToken);

            return new TaskItemDto (
                task.Id, task.Title, task.Description, task.Status,task.Deadline, task.AssigneeId, task.CreatorId, task.CreatedAt);
        }
    }
}

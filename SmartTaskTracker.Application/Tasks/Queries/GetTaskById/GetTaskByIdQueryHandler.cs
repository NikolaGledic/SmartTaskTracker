using MediatR;
using SmartTaskTracker.Application.Tasks.DTOs;
using SmartTaskTracker.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTaskTracker.Application.Tasks.Queries.GetTaskById
{
    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, TaskItemDto?>
    {
        private readonly SmartTaskTrackerDbContext _context;
        public GetTaskByIdQueryHandler(SmartTaskTrackerDbContext context) => _context = context;

        public async Task<TaskItemDto?> Handle (GetTaskByIdQuery query, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks.FindAsync(new object[] { query.Id }, cancellationToken);

            if (task == null) return null;
            return new TaskItemDto(
                task.Id, task.Title, task.Description, task.Status, task.Deadline, task.AssigneeId, task.CreatorId, task.CreatedAt);
        }
    }
}

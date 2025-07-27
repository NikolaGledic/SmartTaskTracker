using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartTaskTracker.Application.Tasks.DTOs;
using SmartTaskTracker.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTaskTracker.Application.Tasks.Queries.GetAllTasks
{
    public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, List<TaskItemDto>>
    {
        private readonly SmartTaskTrackerDbContext _context;
        public GetAllTasksQueryHandler(SmartTaskTrackerDbContext context) { _context = context; }

        public async Task<List<TaskItemDto>> Handle(GetAllTasksQuery query, CancellationToken cancellationToken)
        {
            return await _context.Tasks.Select(t => new TaskItemDto(t.Id, t.Title,t.Description, t.Status, t.Deadline, t.AssigneeId, t.CreatorId, t.CreatedAt)).ToListAsync(cancellationToken);
        }
    }
}

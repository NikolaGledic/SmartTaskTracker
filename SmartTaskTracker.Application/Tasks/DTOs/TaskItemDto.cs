using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTaskTracker.Application.Tasks.DTOs
{
    public record TaskItemDto(
        Guid Id,
        string Title,
        string? Description,
        string Status,
        DateTime? Deadline,
        Guid? AssigneeId,
        Guid CreatorId,
        DateTime CreatedAt
        );
    
}

using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartTaskTracker.Application.Users.DTOs;
using SmartTaskTracker.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTaskTracker.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler <GetAllUsersQuery, List<UserDto>>
    {
        private readonly SmartTaskTrackerDbContext _context;
        public GetAllUsersQueryHandler(SmartTaskTrackerDbContext context) => _context = context;

        public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users.Select(u => new UserDto(u.Id, u.Username, u.Email, u.CreatedAt))
                .ToListAsync(cancellationToken);
        }
    }
}

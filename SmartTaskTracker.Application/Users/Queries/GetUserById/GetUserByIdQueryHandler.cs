using MediatR;
using SmartTaskTracker.Application.Users.DTOs;
using SmartTaskTracker.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTaskTracker.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto?>
    {
        private readonly SmartTaskTrackerDbContext _context;
        public GetUserByIdQueryHandler(SmartTaskTrackerDbContext context) => _context = context;

        public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(new object[] { request.Id }, cancellationToken);
            if (user == null) return null;

            return new UserDto(user.Id, user.Username, user.Email, user.CreatedAt);
        }
    }
}

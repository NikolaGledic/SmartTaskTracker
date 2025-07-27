using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartTaskTracker.Application.Users.DTOs;
using SmartTaskTracker.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTaskTracker.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDto?>
    {
        private readonly SmartTaskTrackerDbContext _context;
        public UpdateUserCommandHandler(SmartTaskTrackerDbContext context) => _context = context;

        public async Task<UserDto> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u =>  u.Id == command.Id, cancellationToken);
            if (user == null) return null;

            user.Username = command.Username;
            user.Email = command.Email;

            await _context.SaveChangesAsync(cancellationToken);
            return new UserDto(user.Id, user.Username, user.Email, user.CreatedAt);
        }
    }
}

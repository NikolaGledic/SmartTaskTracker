using MediatR;
using SmartTaskTracker.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTaskTracker.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly SmartTaskTrackerDbContext _context;
        public DeleteUserCommandHandler(SmartTaskTrackerDbContext context) => _context = context;

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(new object[] {request.Id}, cancellationToken);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}

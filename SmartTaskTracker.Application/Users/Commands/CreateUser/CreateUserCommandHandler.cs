using MediatR;
using SmartTaskTracker.Application.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartTaskTracker.Infrastructure.Data;
using SmartTaskTracker.Core.Entities;
using System.Threading;

namespace SmartTaskTracker.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly SmartTaskTrackerDbContext _db;

        public CreateUserCommandHandler(SmartTaskTrackerDbContext db)
        {
            _db = db;
        }
        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
                Email = request.Email,
                //TODO: zameni hesiranjem:
                PasswordHash = request.Password,
                CreatedAt = DateTime.UtcNow
            };
            _db.Users.Add(user);
            await _db.SaveChangesAsync(cancellationToken);

            return new UserDto(user.Id, user.Username, user.Email, user.CreatedAt);
        }

    }
}

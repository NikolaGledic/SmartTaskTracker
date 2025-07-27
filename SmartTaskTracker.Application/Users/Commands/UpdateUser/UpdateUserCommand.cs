using MediatR;
using SmartTaskTracker.Application.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTaskTracker.Application.Users.Commands.UpdateUser
{
    public record UpdateUserCommand(
        Guid Id,
        string Username,
        string Email
        ) : IRequest<UserDto>;
    
}

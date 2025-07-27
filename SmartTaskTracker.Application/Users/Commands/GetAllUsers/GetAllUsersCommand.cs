using MediatR;
using SmartTaskTracker.Application.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTaskTracker.Application.Users.Commands.GetAllUsers
{
    public record GetAllUsersCommand() : IRequest<List<UserDto>>;
    
}

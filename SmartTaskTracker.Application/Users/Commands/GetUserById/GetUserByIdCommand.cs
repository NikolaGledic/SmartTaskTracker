using MediatR;
using SmartTaskTracker.Application.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTaskTracker.Application.Users.Commands.GetUserById
{
    public record GetUserByIdCommand(Guid Id) : IRequest<UserDto>;
   
}

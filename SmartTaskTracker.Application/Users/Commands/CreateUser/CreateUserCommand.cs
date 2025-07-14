using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SmartTaskTracker.Application.Users.DTOs;

namespace SmartTaskTracker.Application.Users.Commands.CreateUser
{
    public record CreateUserCommand
    (
        string Username,
        string Email,
        string Password //cuvamo plain text a naknadno hashujemo
    ) : IRequest<UserDto>;

}

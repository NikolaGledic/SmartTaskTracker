using MediatR;
using SmartTaskTracker.Application.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTaskTracker.Application.Users.Queries.GetAllUsers
{
    public record GetAllUsersQuery() : IRequest<List<UserDto>>;
    
}

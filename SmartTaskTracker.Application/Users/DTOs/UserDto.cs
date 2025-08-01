﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTaskTracker.Application.Users.DTOs
{
    public record UserDto
    (
        Guid Id,
        string Username,
        string Email,
        DateTime CreatedAt
    );
}

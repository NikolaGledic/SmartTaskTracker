using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartTaskTracker.Application.Users.Commands.CreateUser;

namespace SmartTaskTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IMediator _mediator;
        public UsersController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var dto = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }
    }
}

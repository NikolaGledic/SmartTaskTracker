using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartTaskTracker.Application.Users.Commands.CreateUser;
using SmartTaskTracker.Application.Users.Commands.DeleteUser;
using SmartTaskTracker.Application.Users.Commands.GetAllUsers;
using SmartTaskTracker.Application.Users.Commands.GetUserById;
using SmartTaskTracker.Application.Users.Commands.UpdateUser;
using SmartTaskTracker.Application.Users.DTOs;

namespace SmartTaskTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IMediator _mediator;
        public UsersController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            var dto = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetUserById), new { id = dto.Id }, dto);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UserDto>> GetUserById([FromRoute] Guid id)
        {
            var query = new GetUserByIdQuery(id);
            var user = await _mediator.Send(query);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> GetAllUsers()
        {
            var users = await _mediator.Send(new GetAllUsersQuery());
            return Ok(users);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var success = await _mediator.Send(new DeleteUserCommand(id));
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<UserDto>> UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserCommand command)
        {
            if (id != command.Id) return BadRequest("Pogresan Id");

            var updated = await _mediator.Send(command);
            if (updated == null)
                return NotFound();
            return Ok(updated);
        }
    }
}

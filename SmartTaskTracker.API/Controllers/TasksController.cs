using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartTaskTracker.Application.Tasks.Commands.CreateTaskItem;
using SmartTaskTracker.Application.Tasks.DTOs;
using SmartTaskTracker.Application.Tasks.Queries.GetAllTasks;
using SmartTaskTracker.Application.Tasks.Queries.GetTaskById;

namespace SmartTaskTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TasksController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskItemCommand cmd)
        {
            var dto = await _mediator.Send(cmd);
            return CreatedAtAction(nameof(GetTaskById), new {id = dto.Id}, dto);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TaskItemDto>> GetTaskById(Guid id)
        {
            var dto = await _mediator.Send(new GetTaskByIdQuery(id));
            if (dto == null)
                return NotFound();
            return Ok(dto);
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskItemDto>>> GetAllTasks()
        {
            var list = await _mediator.Send(new GetAllTasksQuery());
            return Ok(list);
        }
    }
}

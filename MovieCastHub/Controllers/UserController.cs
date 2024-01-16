using Application.Dtos.User;
using Application.Users.Commands.CreateUser;
using Application.Users.Querys.GetAllUsers;
using Application.Users.Querys.GetUsersById;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<UserDto>>> GetAllUsers()
        {
            var query = new GetAllUsersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var query = new GetUsersByIdQuery(id);
            var user = await _mediator.Send(query);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound($"No user found with ID '{id}'.");
            }
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserDto userDto)
        {
            var command = new CreateUserCommand(userDto);
            var user = await _mediator.Send(command);
            if (user != null)
            {
                return Ok(user);
            }

            return BadRequest("Unable to create user.");
        }

    }
}

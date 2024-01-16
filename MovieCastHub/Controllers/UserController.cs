using Application.Dtos.User;
using Application.Users.Commands.CreateUser;
using Application.Users.Commands.DeleteUser;
using Application.Users.Commands.UpdateUser;
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

        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            try
            {
                var query = new GetUsersByIdQuery(id);
                var user = await _mediator.Send(query);
                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserDto userDto)
        {
            try
            {
                var command = new CreateUserCommand(userDto);
                var user = await _mediator.Send(command);
                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserUpdateDto userUpdateDto)
        {
            try
            {
                var command = new UpdateUserCommand(id, userUpdateDto);
                var updatedUser = await _mediator.Send(command);
                return Ok(updatedUser);
            }
            catch (ArgumentException ex) when (ex.Message == "User not found")
            {
                return NotFound(ex.Message);
            }

        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                var command = new DeleteUserCommand(id);
                await _mediator.Send(command);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

        }

    }
}

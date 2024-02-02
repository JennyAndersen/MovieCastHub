﻿using Application.Dtos.MovieUser;
using Application.Exceptions;
using Application.MovieUsers.Commands.AddMovieUser;
using Application.MovieUsers.Commands.DeleteMovieUserById;
using Application.MovieUsers.Commands.UpdateMovieUserByUserId;
using Application.MovieUsers.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieUserController : ControllerBase
    {
        internal readonly IMediator _mediator;

        public MovieUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getAllMovieUsers")]
        public async Task<IActionResult> GetAllMovieUsers()
        {
            try
            {
                var allMovieUsers = await _mediator.Send(new GetAllMovieUsersQuery());
                return Ok(allMovieUsers);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Servor Error");
            }
        }

        [HttpPost]
        [Route("addNewMovieUser")]
        public async Task<IActionResult> AddMovieUser([FromBody] MovieUserDto newMovieUser)
        {
            try
            {
                var result = await _mediator.Send(new AddMovieUserCommand(newMovieUser));
                return result == false ? BadRequest("Could not add the animaluser.") : Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Servor Error");
            }
        }

        [HttpPost]
        [Route("updateMovieUser/{updatedUserMovieId}")]
        public async Task<IActionResult> UpdateMovieUser(UpdateMovieUserByUserIdCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return command == null ? BadRequest("Invalid update movieuser command data.") : Ok(result);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Servor Error");
            }
        }

        [HttpDelete]
        [Route("deleteMovieUser/{deletedUserMovieId}")]
        public async Task<IActionResult> DeleteMovieUser(Guid deletedUserMovieId)
        {
            try
            {
                var result = await _mediator.Send(new DeleteMovieUserByIdCommand(deletedUserMovieId));
                return result == false ? BadRequest("Invalid delete animal user command data.") : Ok(result);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Servor Error");
            }
        }
    }
}

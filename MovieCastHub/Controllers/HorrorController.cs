using Application.Dtos.Movie;
using Application.Exceptions;
using Application.Movies.Commands.Horrors.AddHorrorMovie;
using Application.Movies.Commands.Horrors.DeleteHorrorMovieById;
using Application.Movies.Commands.Horrors.UpdateHorrorMovie;
using Application.Movies.Queries.Horrors.GetAllHorror;
using Application.Movies.Queries.Horrors.GetHorrorMovieByDirector;
using Application.Movies.Queries.Horrors.GetHorrorMovieByTitle;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorrorController : ControllerBase
    {

        internal readonly IMediator _mediator;

        public HorrorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //  Get all HorroMovies

        [HttpGet]
        [Route("getAllHorrorMovie")]
        public async Task<IActionResult> GetAllHorrorMovies()
        {

            try
            {
                var horrorMovies = await _mediator.Send(new GetAllHorrorMoviesQuery());
                return Ok(horrorMovies);
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

        // Get HorrorMovie by Title 

        [HttpGet]
        [Route("getHorrorMovieByTitle/{title}")]
        public async Task<IActionResult> GetHorrorMovieByTitle(string title)
        {
            try
            {
                var horrorMovie = await _mediator.Send(new GetHorrorMovieByTitleQuery(title));
                return Ok(horrorMovie);
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

        // Get HorroMovie by Direcgtor 
        [HttpGet]
        [Route("getHorrorMovieByDirector/{director}")]
        public async Task<IActionResult> GetHorrorMovieByDirector(string director)
        {
            try
            {
                var horrorMovie = await _mediator.Send(new GetHorrorMovieByDirectorQuery(director));
                return Ok(horrorMovie);
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

        // Add new HorroMovie 

        [HttpPost]
        [Route("addNewHorrorMovie")]
        public async Task<IActionResult> AddHorrorMovieC([FromBody] HorrorMovieDto newHorrorMovie)
        {
            try
            {
                var result = await _mediator.Send(new AddHorrorMovieCommand(newHorrorMovie));
                return result == null ? BadRequest("Could not add the horror movies.") : Ok(newHorrorMovie);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Servor Error");
            }
        }


        //// Update HorrorMovie 

        [HttpPut]
        [Route("updateHorrorMovie/{updatedHorrorMovieId}")]
        public async Task<IActionResult> UpdateHorrorMovie([FromBody] UpdateMovieDto updatedHorrorMovie, Guid updatedHorrorMovieId)
        {
            try
            {
                var result = await _mediator.Send(new UpdateHorrorMovieByIdCommand(updatedHorrorMovie, updatedHorrorMovieId));
                return Ok(updatedHorrorMovie);
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
        [Route("deleteHorrorMovies/{deletedHorrorMovieId}")]
        public async Task<IActionResult> DeleteHorrorMovie(Guid deletedHorrorMovieId)
        {
            try
            {
                var result = await _mediator.Send(new DeleteHorrorMovieByIdCommand(deletedHorrorMovieId));
                return Ok($"Movie with ID '{deletedHorrorMovieId}' has been deleted.");
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

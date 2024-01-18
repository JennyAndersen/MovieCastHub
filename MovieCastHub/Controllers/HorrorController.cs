using Application.Dtos.Movie;
using Application.Movies.Commands.Horrors.AddHorrorMovie;
using Application.Movies.Commands.Horrors.DeleteHorrorMovieById;
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
                return horrorMovies == null ? NotFound("No horror movies found.") : Ok(horrorMovies);
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
                return horrorMovie == null ? NotFound($"No movie found with title '{title}'.") : Ok(horrorMovie);
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
                return horrorMovie == null ? NotFound($"No movies found with  '{director}'.") : Ok(horrorMovie);
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

        //[HttpPut]
        //[Route("updateHorrorMovie/{updatedHorrorMovieId}")]

        // Delete HorrorMovie by ID 

        [HttpDelete]
        [Route("deleteHorrorMovies/{deletedHorrorMovieId}")]
        public async Task<IActionResult> DeleteHorrorMovie(Guid deletedHorrorMovieId)
        {
            var result = await _mediator.Send(new DeleteHorrorMovieByIdCommand(deletedHorrorMovieId));
            return result != null ? Ok($"Movie with ID '{deletedHorrorMovieId}' has been deleted.") : NotFound($"No Movie found with ID '{deletedHorrorMovieId}' for deletion.");
        }

    }

}

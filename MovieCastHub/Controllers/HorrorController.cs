using Application.Dtos.Movie;
using Application.Movies.Commands.Horrors.AddHorrorMovie;
using Application.Movies.Queries.Comedies.GetComedyMovieByDirector;
using Application.Movies.Queries.Horrors.GetAllHorror;
using Application.Movies.Queries.Horrors.GetHorrorMovieByDirector;
using MediatR;
using Microsoft.AspNetCore.Mvc;
//test
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

        // Get HorroMovie by Title 

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

        /*
        // Update HorrorMovie 

        [HttpPut]
        [Route("updateHorrorMovie/{updatedHorrorMovieId}")]

        // Delete HorrorMovie by ID 

        [HttpDelete]
        [Route("deleteHorrorMovies/{deletedHorrorMovieId}")]
        */
    }

}

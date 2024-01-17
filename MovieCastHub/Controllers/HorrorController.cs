using Application.Dtos.Movie;
using Application.Movies.Commands.Horrors.AddHorrorMovie;
using MediatR;
using Microsoft.AspNetCore.Mvc;
//hej<3
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

        // Get all HorroMovies 

        //[HttpGet]
        //[Route("getAllHorroMovie")]
        //public async Task<IActionResult> GetAllHorrorMovies()
        //{

        //    try
        //    {
        //        var comedyMovies = await _mediator.Send(new GetAllComedyMoviesQuery());
        //        return comedyMovies == null ? NotFound("No horror movies found.") : Ok(comedyMovies);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(500, "Internal Servor Error");
        //    }

        //}
        /*
        // Get HorroMovie by Title 

        // Get HorroMovie by Direcgtor 

       
        */

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

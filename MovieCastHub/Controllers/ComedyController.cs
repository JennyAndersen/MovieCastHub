using Application.Dtos.Movie;
using Application.Movies.Commands.Comedies.AddComedyMovie;
using Application.Movies.Queries.Comedies.GetAllComedy;
using Application.Movies.Queries.Comedies.GetComedyMovieByTitle;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComedyController : ControllerBase
    {

        internal readonly IMediator _mediator;

        public ComedyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Get all comedy movies 

        [HttpGet]
        [Route("getAllComedyMovies")]
        public async Task<IActionResult> GetAllComedyMovies()
        {

            try
            {
                var comedyMovies = await _mediator.Send(new GetAllComedyMoviesQuery());
                return comedyMovies == null ? NotFound("No comedy movies found.") : Ok(comedyMovies);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Servor Error");
            }

        }

        // Get ComedyMovie by Title 
        [HttpGet]
        [Route("getComedyMovieByTitle/{title}")]
        public async Task<IActionResult> GetComedyMovieByTitle(string title)
        {
            try
            {
                var comedyMovie = await _mediator.Send(new GetComedyMovieByTitleQuery(title));
                return comedyMovie == null ? NotFound($"No movie found with title '{title}'.") : Ok(comedyMovie);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Servor Error");
            }
        }

        // Get ComedyMovie by Director 
        // [HttpGet]
        // [Route("getComedyMovieByTitle/{title}")]


        // Add new ComedyMovie 
        [HttpPost]
        [Route("addNewComedyMovie")]
        public async Task<IActionResult> AddComedyMovie([FromBody] ComedyMovieDto newComedyMovie)
        {
            try
            {
                var result = await _mediator.Send(new AddComedyMovieCommand(newComedyMovie));
                return result == null ? BadRequest("Could not add the comedy moview.") : Ok(newComedyMovie);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Servor Error");
            }
        }

        /*
        // Update ComedyMovie 

        [HttpPut]
        [Route("updateComedyMovie/{updatedComedyMovieId}")]

        // Delete ComedyMovie by ID 

        [HttpDelete]
        [Route("deleteComedyMovies/{deletedComedyMovieIdw}")]
        */
    }

}

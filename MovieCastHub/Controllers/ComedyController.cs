using Application.Dtos.Movie;
using Application.Movies.Commands.Comedies.AddComedyMovie;
using Application.Movies.Commands.Comedies.DeleteComedyMovieById;
using Application.Movies.Commands.Comedies.UpdateComedyMovieById;
using Application.Movies.Queries.Comedies.GetAllComedy;
using Application.Movies.Queries.Comedies.GetComedyMovieByDirector;
using Application.Movies.Queries.Comedies.GetComedyMovieByTitle;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        [Route("getComedyMovieByDirector/{director}")]
        public async Task<IActionResult> GetComedyMovieByDirector(string director)
        {
            try
            {
                var comedyMovie = await _mediator.Send(new GetComedyMovieByDirectorQuery(director));
                return comedyMovie == null ? NotFound($"No movie found with title '{director}'.") : Ok(comedyMovie);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Servor Error");
            }
        }

        [HttpPost]
        [Route("addNewComedyMovie")]
        [Authorize(Roles = "Admin")]
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

        [HttpPut]
        [Route("updateComedyMovie/{updatedComedyMovieId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateComedyMovie([FromBody] UpdateMovieDto updatedComedyMovie, Guid updatedComedyMovieId)
        {
            var result = await _mediator.Send(new UpdateComedyMovieByIdCommand(updatedComedyMovie, updatedComedyMovieId));
            return result == null ? NotFound($"No bird found with ID '{updatedComedyMovieId}' for updating.") : Ok(updatedComedyMovie);
        }

        [HttpDelete]
        [Route("deleteComedyMovie/{deletedComedyMovieId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteComedyMovie(Guid deletedComedyMovieId)
        {
            var result = await _mediator.Send(new DeleteComedyMovieByIdCommand(deletedComedyMovieId));
            return result != null ? Ok($"Movie with ID '{deletedComedyMovieId}' has been deleted.") : NotFound($"No Movie found with ID '{deletedComedyMovieId}' for deletion.");
        }
    }
}

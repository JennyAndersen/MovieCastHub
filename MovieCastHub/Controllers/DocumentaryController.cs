using Application.Dtos.Movie;
using Application.Exceptions;
using Application.Movies.Commands.Documentaries.AddDocumentaryMovie;
using Application.Movies.Commands.Documentaries.DeleteDocumentaryMovieById;
using Application.Movies.Commands.Documentaries.UpdateDocumentaryMovieById;
using Application.Movies.Queries.Documentaries.GetAllDocumentary;
using Application.Movies.Queries.Documentaries.GetDocumentaryMovieByDirector;
using Application.Movies.Queries.Documentaries.GetDocumentaryMovieByTitle;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentaryController : ControllerBase
    {
        internal readonly IMediator _mediator;

        public DocumentaryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getAllDocumentaryMovies")]
        public async Task<IActionResult> GetAllDocumentaryMovies()
        {
            try
            {
                var documentaryMovies = await _mediator.Send(new GetAllDocumentaryMoviesQuery());
                return documentaryMovies == null ? NotFound("No Documentary movies found.") : Ok(documentaryMovies);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Servor Error");
            }
        }

        [HttpGet]
        [Route("getDocumentaryMovieByTitle/{title}")]
        public async Task<IActionResult> GetDocumentaryMovieByTitle(string title)
        {
            try
            {
                var documentaryMovie = await _mediator.Send(new GetDocumentaryMovieByTitleQuery(title));
                return documentaryMovie == null ? NotFound($"No movie found with title '{title}'.") : Ok(documentaryMovie);
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

        [HttpGet]
        [Route("getDocumentaryMovieByDirector/{director}")]
        public async Task<IActionResult> GetDocumentaryMovieByDirector(string director)
        {
            try
            {
                var documentaryMovie = await _mediator.Send(new GetDocumentaryMovieByDirectorQuery(director));
                return Ok(documentaryMovie);
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
        [Route("addNewDocumentaryMovie")]
        public async Task<IActionResult> AddDocumentaryMovie([FromBody] DocumentaryMovieDto newDocumentaryMovie)
        {
            try
            {
                var result = await _mediator.Send(new AddDocumentaryMovieCommand(newDocumentaryMovie));
                return result == null ? BadRequest("Could not add the Documentary moview.") : Ok(newDocumentaryMovie);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Servor Error");
            }
        }

        [HttpPut]
        [Route("updateDocumentaryMovie/{updatedDocumentaryMovieId}")]
        public async Task<IActionResult> UpdateDocumentaryMovie([FromBody] UpdateMovieDto updatedDocumentaryMovie, Guid updatedDocumentaryMovieId)
        {
            try
            {
                var result = await _mediator.Send(new UpdateDocumentaryMovieByIdCommand(updatedDocumentaryMovie, updatedDocumentaryMovieId));
                return Ok(updatedDocumentaryMovie);
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
        [Route("deleteDocumentaryMovie/{deletedDocumentaryMovieId}")]
        public async Task<IActionResult> DeleteDocumentaryMovie(Guid deletedDocumentaryMovieId)
        {
            try
            {
                var result = await _mediator.Send(new DeleteDocumentaryMovieByIdCommand(deletedDocumentaryMovieId));
                return Ok($"Movie with ID '{deletedDocumentaryMovieId}' has been deleted.");
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

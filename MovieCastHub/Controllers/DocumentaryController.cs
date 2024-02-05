using Application.Dtos.Movie;
using Application.Movies.Commands.Documentaries.AddDocumentaryMovie;
using Application.Movies.Commands.Documentaries.DeleteDocumentaryMovieById;
using Application.Movies.Commands.Documentaries.UpdateDocumentaryMovieById;
using Application.Movies.Queries.Documentaries.GetAllDocumentary;
using Application.Movies.Queries.Documentaries.GetDocumentaryMovieByDirector;
using Application.Movies.Queries.Documentaries.GetDocumentaryMovieByTitle;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
                return documentaryMovie == null ? NotFound($"No movie found with title '{director}'.") : Ok(documentaryMovie);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Servor Error");
            }
        }

        [HttpPost]
        [Route("addNewDocumentaryMovie")]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateDocumentaryMovie([FromBody] UpdateMovieDto updatedDocumentaryMovie, Guid updatedDocumentaryMovieId)
        {
            var result = await _mediator.Send(new UpdateDocumentaryMovieByIdCommand(updatedDocumentaryMovie, updatedDocumentaryMovieId));
            return result == null ? NotFound($"No bird found with ID '{updatedDocumentaryMovieId}' for updating.") : Ok(updatedDocumentaryMovie);
        }

        [HttpDelete]
        [Route("deleteDocumentaryMovie/{deletedDocumentaryMovieId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteDocumentaryMovie(Guid deletedDocumentaryMovieId)
        {
            var result = await _mediator.Send(new DeleteDocumentaryMovieByIdCommand(deletedDocumentaryMovieId));
            return result != null ? Ok($"Movie with ID '{deletedDocumentaryMovieId}' has been deleted.") : NotFound($"No Movie found with ID '{deletedDocumentaryMovieId}' for deletion.");
        }
    }
}

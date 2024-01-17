using Application.Movies.Queries.Documentaries.GetAllDocumentary;
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
    }
}
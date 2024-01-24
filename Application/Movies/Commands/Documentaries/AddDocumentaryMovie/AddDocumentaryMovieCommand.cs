using Application.Dtos.Movie;
using Domain.Models;
using MediatR;

namespace Application.Movies.Commands.Documentaries.AddDocumentaryMovie
{
    public class AddDocumentaryMovieCommand : IRequest<Documentary>
    {
        public AddDocumentaryMovieCommand(DocumentaryMovieDto newDocumentaryMovie)
        {
            NewDocumentaryMovie = newDocumentaryMovie;
        }
        public DocumentaryMovieDto NewDocumentaryMovie { get; set; }
    }
}

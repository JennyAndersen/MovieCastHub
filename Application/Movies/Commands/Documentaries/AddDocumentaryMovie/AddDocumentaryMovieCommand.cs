using Application.Behavior;
using Application.Behavior.Validators;
using Application.Behavior.Validators.Movie;
using Application.Dtos.Movie;
using Domain.Models;
using MediatR;

namespace Application.Movies.Commands.Documentaries.AddDocumentaryMovie
{
    public class AddDocumentaryMovieCommand : IRequest<Documentary>, IValidate
    {
        public AddDocumentaryMovieCommand(DocumentaryMovieDto newDocumentaryMovie)
        {
            NewDocumentaryMovie = newDocumentaryMovie;
        }
        public DocumentaryMovieDto NewDocumentaryMovie { get; set; }

        public void Validate()
        {
            ValidationHelper.ValidateAndThrow(NewDocumentaryMovie, new DocumentaryMovieDtoValidator());
        }
    }
}

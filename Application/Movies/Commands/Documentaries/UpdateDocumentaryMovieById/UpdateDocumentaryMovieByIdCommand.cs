using Application.Dtos.Movie;
using Domain.Models;
using MediatR;

namespace Application.Movies.Commands.Documentaries.UpdateDocumentaryMovieById
{
    public class UpdateDocumentaryMovieByIdCommand : IRequest<Documentary>
    {
        public UpdateDocumentaryMovieByIdCommand(UpdateMovieDto updatedDocumentaryMovie, Guid id)
        {
            UpdatedDocumentaryMovie = updatedDocumentaryMovie;
            Id = id;
        }

        public UpdateMovieDto UpdatedDocumentaryMovie { get; }
        public Guid Id { get; }
    }
}

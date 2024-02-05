using Application.Behavior;
using Application.Behavior.Validators;
using Application.Behavior.Validators.Common;
using Application.Behavior.Validators.Movie;
using Application.Dtos.Movie;
using Domain.Models;
using MediatR;

namespace Application.Movies.Commands.Documentaries.UpdateDocumentaryMovieById
{
    public class UpdateDocumentaryMovieByIdCommand : IRequest<Documentary>, IValidate
    {
        public UpdateDocumentaryMovieByIdCommand(UpdateMovieDto updatedDocumentaryMovie, Guid id)
        {
            UpdatedDocumentaryMovie = updatedDocumentaryMovie;
            Id = id;
        }

        public UpdateMovieDto UpdatedDocumentaryMovie { get; }
        public Guid Id { get; }

        public void Validate()
        {
            ValidationHelper.ValidateAndThrow(UpdatedDocumentaryMovie, new RatingValidator());
            ValidationHelper.ValidateAndThrow(Id, new GuidValidator());
        }
    }
}

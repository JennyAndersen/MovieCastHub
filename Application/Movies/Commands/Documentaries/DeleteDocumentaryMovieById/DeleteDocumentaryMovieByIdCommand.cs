using Application.Behavior;
using FluentValidation;
using MediatR;

namespace Application.Movies.Commands.Documentaries.DeleteDocumentaryMovieById
{
    public class DeleteDocumentaryMovieByIdCommand : IRequest<bool>, IValidate
    {
        public DeleteDocumentaryMovieByIdCommand(Guid movieId)
        {
            MovieId = movieId;
        }

        public Guid MovieId { get; }

        public void Validate()
        {
            ValidationHelper.ValidateAndThrow(MovieId, new GuidValidator());
        }
    }
}

using Application.Behavior;
using Application.Behavior.Validators;
using Application.Behavior.Validators.Common;
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

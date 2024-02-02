using Application.Behavior;
using Application.Behavior.Validators;
using MediatR;

namespace Application.Movies.Commands.Horrors.DeleteHorrorMovieById
{
    public class DeleteHorrorMovieByIdCommand : IRequest<bool>, IValidate
    {
        public DeleteHorrorMovieByIdCommand(Guid movieId)
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

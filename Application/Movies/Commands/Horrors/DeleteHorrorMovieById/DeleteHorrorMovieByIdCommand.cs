using MediatR;

namespace Application.Movies.Commands.Horrors.DeleteHorrorMovieById
{
    public class DeleteHorrorMovieByIdCommand : IRequest<bool>
    {
        public DeleteHorrorMovieByIdCommand(Guid movieId)
        {
            MovieId = movieId;
        }

        public Guid MovieId { get; }
    }
}

using MediatR;

namespace Application.Movies.Commands.Comedies.DeleteComedyMovieById
{
    public class DeleteComedyMovieByIdCommand : IRequest<bool>
    {
        public DeleteComedyMovieByIdCommand(Guid movieId)
        {
            MovieId = movieId;
        }

        public Guid MovieId { get; }
    }
}

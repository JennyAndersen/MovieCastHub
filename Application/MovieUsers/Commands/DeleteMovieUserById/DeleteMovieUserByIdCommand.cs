using MediatR;

namespace Application.MovieUsers.Commands.DeleteMovieUserById
{
    public class DeleteMovieUserByIdCommand : IRequest<bool>
    {
        public DeleteMovieUserByIdCommand(Guid userMovieId)
        {
            UserMovieId = userMovieId;
        }

        public Guid UserMovieId { get; }
    }
}

using MediatR;

namespace Application.MovieUsers.Commands.UpdateMovieUserByUserId
{
    public class UpdateMovieUserByUserIdCommand : IRequest<bool>
    {
        public UpdateMovieUserByUserIdCommand(float newUserRating)
        {
            NewUserRating = newUserRating;
        }

        public Guid UserMovieId { get; }
        public float NewUserRating { get; }
    }
}

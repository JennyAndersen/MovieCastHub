using Application.Behavior;
using Application.Behavior.Validators;
using MediatR;

namespace Application.MovieUsers.Commands.UpdateMovieUserByUserId
{
    public class UpdateMovieUserByUserIdCommand : IRequest<bool>, IValidate
    {
        public UpdateMovieUserByUserIdCommand(float newUserRating)
        {
            NewUserRating = newUserRating;
        }

        public Guid UserMovieId { get; }
        public float NewUserRating { get; }

        public void Validate()
        {
            ValidationHelper.ValidateAndThrow(UserMovieId, new GuidValidator());
            ValidationHelper.ValidateAndThrow(NewUserRating, new FloatValidator());
        }
    }
}

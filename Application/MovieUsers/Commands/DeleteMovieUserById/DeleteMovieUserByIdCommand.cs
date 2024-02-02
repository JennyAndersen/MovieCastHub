using Application.Behavior;
using Application.Behavior.Validators;
using Application.Behavior.Validators.Common;
using MediatR;

namespace Application.MovieUsers.Commands.DeleteMovieUserById
{
    public class DeleteMovieUserByIdCommand : IRequest<bool>, IValidate
    {
        public DeleteMovieUserByIdCommand(Guid userMovieId)
        {
            UserMovieId = userMovieId;
        }

        public Guid UserMovieId { get; }

        public void Validate()
        {
            ValidationHelper.ValidateAndThrow(UserMovieId, new GuidValidator());
        }
    }
}

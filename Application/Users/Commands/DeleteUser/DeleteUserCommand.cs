using Application.Behavior;
using Application.Behavior.Validators;
using Application.Behavior.Validators.Common;
using MediatR;


namespace Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest, IValidate
    {
        public Guid UserId { get; }

        public DeleteUserCommand(Guid userId)
        {
            UserId = userId;
        }

        public void Validate()
        {
            ValidationHelper.ValidateAndThrow(UserId, new GuidValidator());
        }
    }
}

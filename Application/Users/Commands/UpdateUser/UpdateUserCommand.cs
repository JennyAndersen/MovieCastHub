using Application.Behavior;
using Application.Behavior.Validators;
using Application.Behavior.Validators.Common;
using Application.Behavior.Validators.User;
using Application.Dtos.User;
using Domain.Models;
using MediatR;


namespace Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<User>, IValidate
    {
        public Guid UserId { get; set; }
        public UserUpdateDto UserUpdateDto { get; set; }

        public UpdateUserCommand(Guid userId, UserUpdateDto userUpdateDto)
        {
            UserId = userId;
            UserUpdateDto = userUpdateDto;
        }

        public void Validate()
        {
            ValidationHelper.ValidateAndThrow(UserId, new GuidValidator());
            ValidationHelper.ValidateAndThrow(UserUpdateDto, new UserUpdateDtoValidator());
        }
    }
}

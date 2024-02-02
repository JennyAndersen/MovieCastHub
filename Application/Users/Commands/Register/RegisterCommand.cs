#nullable disable
using Application.Behavior;
using Application.Behavior.Validators;
using Application.Behavior.Validators.User;
using Application.Dtos.User;
using Domain.Models;
using MediatR;


namespace Application.Users.Commands.CreateUser
{
    public class RegisterCommand : IRequest<User>, IValidate
    {
        public UserDto UserDto { get; set; }

        public RegisterCommand(UserDto userDto)
        {
            UserDto = userDto;
        }

        public void Validate()
        {
            ValidationHelper.ValidateAndThrow(UserDto, new UserDtoValidator());
        }
    }
}

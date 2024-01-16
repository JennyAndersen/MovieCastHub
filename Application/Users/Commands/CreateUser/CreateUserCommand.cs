#nullable disable
using Application.Dtos.User;
using Domain.Models;
using MediatR;


namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<User>
    {
        public UserDto UserDto { get; set; }

        public CreateUserCommand(UserDto userDto)
        {
            UserDto = userDto;
        }
    }
}

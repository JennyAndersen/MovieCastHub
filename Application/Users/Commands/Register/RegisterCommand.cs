#nullable disable
using Application.Dtos.User;
using Domain.Models;
using MediatR;


namespace Application.Users.Commands.CreateUser
{
    public class RegisterCommand : IRequest<User>
    {
        public UserDto UserDto { get; set; }

        public RegisterCommand(UserDto userDto)
        {
            UserDto = userDto;
        }
    }
}

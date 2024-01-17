using Application.Dtos.User;
using Domain.Models;
using MediatR;


namespace Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<User>
    {
        public Guid UserId { get; set; }
        public UserUpdateDto UserUpdateDto { get; set; }

        public UpdateUserCommand(Guid userId, UserUpdateDto userUpdateDto)
        {
            UserId = userId;
            UserUpdateDto = userUpdateDto;
        }

    }
}

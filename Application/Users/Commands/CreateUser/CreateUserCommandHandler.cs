using Application.Dtos.User;
using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = new User
            {
                Username = request.UserDto.Username,
                Password = request.UserDto.Password
            };

            return await _userRepository.CreateUserAsync(newUser);
        }
    }
}

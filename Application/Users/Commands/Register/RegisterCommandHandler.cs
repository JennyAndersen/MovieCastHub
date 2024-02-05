using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.Users.Commands.CreateUser
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.UserDto.Username) || string.IsNullOrEmpty(request.UserDto.Password))
            {
                throw new ArgumentException("Username and Password are required");
            }

            var newUser = new User
            {
                Username = request.UserDto.Username,
                Password = request.UserDto.Password,
                Role = "User"
            };

            return await _userRepository.CreateUserAsync(newUser);
        }
    }
}

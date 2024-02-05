using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;


namespace Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.UserId);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            // Du behöver inte ändra något här om UserRepository hanterar hashning
            if (!string.IsNullOrWhiteSpace(request.UserUpdateDto.Password))
            {
                user.Password = request.UserUpdateDto.Password;
            }

            await _userRepository.UpdateUserAsync(user);
            return user;
        }
    }
}

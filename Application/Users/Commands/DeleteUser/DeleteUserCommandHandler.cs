using Application.Exceptions;
using Infrastructure.Interfaces;
using MediatR;


namespace Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {

        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.UserId) ?? throw new EntityNotFoundException("User", request.UserId);

            await _userRepository.DeleteUserAsync(request.UserId);
        }
    }
}

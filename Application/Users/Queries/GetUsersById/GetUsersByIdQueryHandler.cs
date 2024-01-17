using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.Users.Querys.GetUsersById
{
    public class GetUsersByIdQueryHandler : IRequestHandler<GetUsersByIdQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetUsersByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserByIdAsync(request.UserId);
        }
    }
}

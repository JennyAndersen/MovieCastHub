using Application.Exceptions;
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
            var user = await _userRepository.GetUserByIdAsync(request.UserId) ?? throw new EntityNotFoundException("User", request.UserId);

            return user;
        }
    }
}

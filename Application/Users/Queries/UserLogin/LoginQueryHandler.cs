#nullable disable
using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.Users.Queries.UserLogin
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, string>
    {
        private readonly IAuthorizationRepository _authorizationRepository;

        public LoginQueryHandler(IAuthorizationRepository authorizationRepository)
        {
            _authorizationRepository = authorizationRepository;
        }
        public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            User user = await _authorizationRepository.ValidateUserCredentialsAsync(request.UserName, request.Password);

            if (user == null)
            {
                return null;
            }

            return _authorizationRepository.GenerateJwtTokenAsync(user);
        }
    }
}

#nullable disable
using Domain.Models;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
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
            var user = await _authorizationRepository.ValidateUserCredentialsAsync(request.UserName, request.Password);

            if (user != null)
            {
                return _authorizationRepository.GenerateJwtTokenAsync(user);
            }
            else
            {
                throw new UnauthorizedAccessException("Autentisering misslyckades. Användarnamnet eller lösenordet är felaktigt.");
            }
        }
    }
}

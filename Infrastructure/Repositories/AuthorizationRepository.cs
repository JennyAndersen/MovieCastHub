#nullable disable
using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Repositories
{
    public class AuthorizationRepository : IAuthorizationRepository
    {

        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public AuthorizationRepository(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }
        public string GenerateJwtTokenAsync(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtConfig:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<User> ValidateUserCredentialsAsync(string username, string password)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);

            if (user == null)
            {
                return null;
            }

            bool passwordVerified = _userRepository.VerifyPassword(password, user.Password);
            if (!passwordVerified)
            {
                return null;
            }

            return user;
        }
    }
}

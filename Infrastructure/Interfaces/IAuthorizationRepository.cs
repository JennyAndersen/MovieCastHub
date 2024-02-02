using Domain.Models;


namespace Infrastructure.Interfaces
{
    public interface IAuthorizationRepository
    {
        string GenerateJwtTokenAsync(User user);
        Task<User> ValidateUserCredentialsAsync(string username, string password);
    }
}

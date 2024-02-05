using Domain.Models;

namespace Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(Guid userId);
        Task<User> CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(Guid userId);
        Task<User> GetUserByUsernameAsync(string username);
        bool VerifyPassword(string inputPassword, string hashedPassword);


    }
}

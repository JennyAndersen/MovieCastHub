using Domain.Models;

namespace Infrastructure.Interfaces
{
    public interface IMovieUserRepository
    {
        Task<bool> AddMovieUserAsync(UserMovie movieUser);
        Task<List<UserMovie>> GetAllMovieUsersAsync();
    }
}

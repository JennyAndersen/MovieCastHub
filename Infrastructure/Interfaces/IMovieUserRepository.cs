using Domain.Models;

namespace Infrastructure.Interfaces
{
    public interface IMovieUserRepository
    {
        Task<bool> AddMovieUserAsync(UserMovie movieUser);
        Task DeleteByIdAsync(Guid userMovieId);
        Task<List<UserMovie>> GetAllMovieUsersAsync();
    }
}

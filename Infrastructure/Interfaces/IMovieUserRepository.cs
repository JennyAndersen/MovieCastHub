using Domain.Models;

namespace Infrastructure.Interfaces
{
    public interface IMovieUserRepository
    {
        Task<bool> AddMovieUserAsync(UserMovie movieUser);
        Task DeleteByIdAsync(Guid userMovieId);
        Task<List<UserMovie>> GetAllMovieUsersAsync();
        Task<UserMovie> GetMovieUserByIdAsync(Guid userMovieId);
        Task UpdateMovieUserAsync(UserMovie movieUser);
    }
}

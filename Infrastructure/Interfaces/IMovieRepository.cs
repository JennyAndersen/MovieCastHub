using Domain.Models;

namespace Infrastructure.Interfaces
{
    public interface IMovieRepository
    {
        Task AddMovieAsync<T>(T entity) where T : class;
        Task DeleteAsync(Guid movieId);
        Task<List<Comedy>> GetAllComedyMoviesAsync();
        Task<List<Horror>> GetAllHorrorsMoviesAsync();
        Task<List<Movie>> GetByDirectorAsync(string director);
        Task<Movie> GetByIdAsync(Guid MovieId);
        Task<List<Movie>> GetByTitleAsync(string title);
        Task UpdateByIdAsync(Movie movieToUpdate);
    }
}

using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _context;
        private readonly ILogger _logger;

        public MovieRepository(MovieDbContext context)
        {
            _context = context;
            _logger = Log.ForContext<MovieRepository>();
        }

        public async Task AddMovieAsync<T>(T entity) where T : class
        {
            try
            {
                _logger.Information("Adding new movie...");
                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();
                _logger.Information("Movie added successfully.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred while adding new movie.");
                throw;
            }
        }

        public async Task DeleteAsync(Guid movieId)
        {
            try
            {
                _logger.Information($"Deleting movie with ID: {movieId}...");
                var movieToDelete = await _context.Movies.FindAsync(movieId) ?? throw new ArgumentNullException(nameof(movieId), "Cannot delete null movie.");
                _context.Movies.Remove(movieToDelete);
                await _context.SaveChangesAsync();
                _logger.Information($"Movie with ID: {movieId} deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"An error occurred while deleting movie with ID: {movieId}.");
                throw;
            }
        }

        public async Task<List<Comedy>> GetAllComedyMoviesAsync()
        {
            try
            {
                _logger.Information("Getting all comedy movies...");
                var comedyMovies = await _context.Movies.OfType<Comedy>().ToListAsync();
                _logger.Information($"Found {comedyMovies.Count} comedy movies.");
                return comedyMovies;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred while getting all comedy movies.");
                throw;
            }
        }

        public async Task<List<Documentary>> GetAllDocumentaryMoviesAsync()
        {
            try
            {
                _logger.Information("Getting all documentary movies...");
                var documentaryMovies = await _context.Movies.OfType<Documentary>().ToListAsync();
                _logger.Information($"Found {documentaryMovies.Count} documentary movies.");
                return documentaryMovies;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred while getting all documentary movies.");
                throw;
            }
        }

        public async Task<List<Horror>> GetAllHorrorsMoviesAsync()
        {
            try
            {
                _logger.Information("Getting all horror movies...");
                var horrorMovies = await _context.Movies.OfType<Horror>().ToListAsync();
                _logger.Information($"Found {horrorMovies.Count} horror movies.");
                return horrorMovies;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred while getting all horror movies.");
                throw;
            }
        }

        public async Task<List<Movie>> GetByDirectorAsync(string director)
        {
            try
            {
                _logger.Information($"Getting movies by director: {director}...");
                var movies = await _context.Movies
                    .Where(m => m.Director == director)
                    .ToListAsync();
                _logger.Information($"Found {movies.Count} movies with director: {director}.");
                return movies;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"An error occurred while getting movies by director: {director}.");
                throw;
            }
        }

        public async Task<Movie> GetByIdAsync(Guid MovieId)
        {
            try
            {
                _logger.Information($"Getting movie by ID: {MovieId}...");
                var movie = await _context.Movies.FindAsync(MovieId);
                _logger.Information($"Found movie with ID: {MovieId}.");
                return movie!;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"An error occurred while getting movie by ID: {MovieId}.");
                throw;
            }
        }

        public async Task<List<Movie>> GetByTitleAsync(string title)
        {
            try
            {
                _logger.Information($"Getting movies by title: {title}...");
                var movies = await _context.Movies
                    .Where(m => m.Title == title)
                    .ToListAsync();
                _logger.Information($"Found {movies.Count} movies with title: {title}.");
                return movies;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"An error occurred while getting movies by title: {title}.");
                throw;
            }
        }

        public async Task UpdateByIdAsync(Movie movieToUpdate)
        {
            try
            {
                _logger.Information($"Updating movie with ID: {movieToUpdate.MovieId}...");
                _context.Movies.Update(movieToUpdate ?? throw new ArgumentNullException(nameof(movieToUpdate), "Cannot update null movie."));
                await _context.SaveChangesAsync();
                _logger.Information($"Movie with ID: {movieToUpdate.MovieId} updated successfully.");

            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"An error occurred while updating movie with ID: {movieToUpdate.MovieId}.");
                throw;
            }
        }
    }
}

using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Infrastructure.Repositories
{
    public class MovieUserRepository : IMovieUserRepository
    {
        private readonly MovieDbContext _context;
        private readonly ILogger _logger;
        public MovieUserRepository(MovieDbContext context)
        {
            _logger = Log.ForContext<MovieUserRepository>();
            _context = context;
        }

        public async Task<bool> AddMovieUserAsync(UserMovie movieUser)
        {
            try
            {
                _logger.Information("Adding new movieUser...");
                await _context.UserMovie.AddAsync(movieUser);
                await _context.SaveChangesAsync();
                _logger.Information("MovieUser added successfully.");
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred while adding new movieUser.");
                throw;
            }

        }

        public async Task DeleteByIdAsync(Guid userMovieId)
        {
            try
            {
                _logger.Information($"Deleting movieUser with ID: {userMovieId}...");
                var movieUserToDelete = await _context.UserMovie.FindAsync(userMovieId) ?? throw new Exception("MovieUser not found");
                _context.UserMovie.Remove(movieUserToDelete);
                await _context.SaveChangesAsync();
                _logger.Information($"MovieUser with ID: {userMovieId} deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"An error occurred while deleting movieUser with ID: {userMovieId}.");
                throw;
            }

        }

        public async Task<List<UserMovie>> GetAllMovieUsersAsync()
        {
            try
            {
                _logger.Information("Getting all movieUser...");
                var allMovieUsers = await _context.UserMovie.OfType<UserMovie>().ToListAsync();
                _logger.Information($"Found {allMovieUsers.Count} movieUser.");
                return allMovieUsers;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred while getting all movieUser.");
                throw;
            }

        }

        public async Task<UserMovie> GetMovieUserByIdAsync(Guid userMovieId)
        {
            try
            {
                _logger.Information($"Getting userMovie by ID: {userMovieId}...");
                var userMovie = await _context.UserMovie.FindAsync(userMovieId);
                _logger.Information($"Found userMovie with ID: {userMovieId}.");
                return userMovie!;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"An error occurred while getting userMovie by ID: {userMovieId}.");
                throw;
            }

        }

        public async Task UpdateMovieUserAsync(UserMovie movieUser)
        {
            try
            {
                _logger.Information($"Updating movieUser with ID: {movieUser.MovieId}...");
                _context.UserMovie.Update(movieUser);
                await _context.SaveChangesAsync();
                _logger.Information($"MovieUser with ID: {movieUser.MovieId} updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"An error occurred while updating movieUser with ID: {movieUser.MovieId}.");
                throw;
            }
        }
    }
}

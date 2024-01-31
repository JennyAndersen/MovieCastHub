#nullable disable
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MovieDbContext _context;
        private readonly ILogger _logger;

        public UserRepository(MovieDbContext context)
        {
            _context = context;
            _logger = Log.ForContext<UserRepository>();
        }
        public async Task<User> CreateUserAsync(User user)
        {
            try
            {
                _logger.Information("Adding new user...");
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                _logger.Information("User added successfully.");
                return user;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred while adding new user.");
                throw;
            }
        }

        public async Task DeleteUserAsync(Guid userId)
        {
            try
            {
                _logger.Information($"Deleting user with ID: {userId}...");
                var user = await _context.Users.FindAsync(userId) ?? throw new ArgumentNullException(nameof(userId), "Cannot delete null user.");
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                _logger.Information($"User with ID: {userId} deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"An error occurred while deleting user with ID: {userId}.");
                throw;
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            try
            {
                _logger.Information("Getting all users...");
                var users = await _context.Users.ToListAsync();
                _logger.Information($"Found {User.Count} users.");
                return await _context.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred while getting all users.");
                throw;
            }
        }

        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            try
            {
                _logger.Information($"Getting user by ID: {userId}...");
                var user = await _context.Users.FindAsync(userId);
                _logger.Information($"Found user with ID: {userId}.");
                return user;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"An error occurred while getting user by ID: {userId}.");
                throw;
            }
        }

        public async Task UpdateUserAsync(User user)
        {
            try
            {
                _logger.Information($"Updating user with ID: {user.UserId}...");
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                _logger.Information($"User with ID: {user.UserId} updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"An error occurred while updating user with ID: {user.UserId}.");
                throw;
            }
        }
    }
}

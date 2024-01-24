using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MovieUserRepository : IMovieUserRepository
    {
        private readonly MovieDbContext _context;

        public MovieUserRepository(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddMovieUserAsync(UserMovie movieUser)
        {
            await _context.UserMovie.AddAsync(movieUser);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task DeleteByIdAsync(Guid userMovieId)
        {
            var movieUserToDelete = await _context.UserMovie.FindAsync(userMovieId) ?? throw new Exception("MovieUser not found");
            _context.UserMovie.Remove(movieUserToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<List<UserMovie>> GetAllMovieUsersAsync()
        {
            var allMovieUsers = await _context.UserMovie.OfType<UserMovie>().ToListAsync();
            return allMovieUsers;
        }

        public async Task<UserMovie> GetMovieUserByIdAsync(Guid userMovieId)
        {
            var userMovie = await _context.UserMovie.FindAsync(userMovieId);
            return userMovie;
        }

        public async Task UpdateMovieUserAsync(UserMovie movieUser)
        {
            _context.UserMovie.Update(movieUser);
            await _context.SaveChangesAsync();
        }
    }
}

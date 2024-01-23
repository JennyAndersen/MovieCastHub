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

        public async Task<List<UserMovie>> GetAllMovieUsersAsync()
        {
            var allMovieUsers = await _context.UserMovie.OfType<UserMovie>().ToListAsync();
            return allMovieUsers;
        }
    }
}

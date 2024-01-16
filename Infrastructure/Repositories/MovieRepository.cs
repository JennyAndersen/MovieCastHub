using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _context;
        public MovieRepository(MovieDbContext context)
        {
            _context = context;
        }

        public async Task AddMovieAsync<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Comedy>> GetAllComedyMoviesQuery()
        {
            var comedyMovies = await _context.Movies.OfType<Comedy>().ToListAsync();
            return comedyMovies;
        }
    }
}

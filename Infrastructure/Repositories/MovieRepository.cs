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

        public async Task DeleteAsync(Guid movieId)
        {
            var comedyMovieToDelete = await _context.Movies.FindAsync(movieId) ?? throw new ArgumentNullException(nameof(movieId), "Cannot delete null movie.");
            _context.Movies.Remove(comedyMovieToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Comedy>> GetAllComedyMoviesQuery()
        {
            var comedyMovies = await _context.Movies.OfType<Comedy>().ToListAsync();
            return comedyMovies;
        }

        public async Task<List<Documentary>> GetAllDocumentaryMoviesQuery()
        {
            var documentaryMovies = await _context.Movies.OfType<Documentary>().ToListAsync();
            return documentaryMovies;
        }

        public async Task<List<Movie>> GetByDirectorAsync(string director)
        {
            return await _context.Movies
        .Where(m => m.Director == director)
        .ToListAsync();
        }

        public async Task<Movie> GetByIdAsync(Guid MovieId)
        {
            var movie = await _context.Movies.FindAsync(MovieId);
            return movie!;
        }

        public async Task<List<Movie>> GetByTitleAsync(string title)
        {
            return await _context.Movies
        .Where(m => m.Title == title)
        .ToListAsync();
        }
    }
}

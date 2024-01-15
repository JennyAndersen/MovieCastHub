using Domain.Models;

namespace Infrastructure
{
    public interface IMovieRepository
    {
        Task<List<Comedy>> GetAllComedyMoviesQuery();
    }
}

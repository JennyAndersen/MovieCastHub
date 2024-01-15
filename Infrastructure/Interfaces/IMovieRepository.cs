using Domain.Models;

namespace Infrastructure.Interfaces
{
    public interface IMovieRepository
    {
        Task<List<Comedy>> GetAllComedyMoviesQuery();
    }
}

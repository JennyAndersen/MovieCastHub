using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.Movies.Queries.Comedies.GetAllComedy
{
    public class GetAllComedyMoviesQueryHandler : IRequestHandler<GetAllComedyMoviesQuery, List<Comedy>>
    {
        private readonly IMovieRepository _movieRepository;

        public GetAllComedyMoviesQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        async Task<List<Comedy>> IRequestHandler<GetAllComedyMoviesQuery, List<Comedy>>.Handle(GetAllComedyMoviesQuery request, CancellationToken cancellationToken)
        {
            List<Comedy> allComedyMovies = await _movieRepository.GetAllComedyMoviesAsync();
            return allComedyMovies;
        }
    }
}

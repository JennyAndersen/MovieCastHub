using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.Movies.Queries.Comedies.GetComedyMovieByDirector
{
    public class GetComedyMovieByDirectorQueryHandler : IRequestHandler<GetComedyMovieByDirectorQuery, List<Movie>>
    {
        private readonly IMovieRepository _movieRepository;
        public GetComedyMovieByDirectorQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<List<Movie>> Handle(GetComedyMovieByDirectorQuery request, CancellationToken cancellationToken)
        {
            var movies = await _movieRepository.GetByDirectorAsync(request.Director);

            var comedyMovies = movies
            .Where(m => m.GetType() == typeof(Comedy))
            .ToList();

            return comedyMovies;
        }
    }
}

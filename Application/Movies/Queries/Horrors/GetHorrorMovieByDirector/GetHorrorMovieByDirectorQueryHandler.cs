using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.Movies.Queries.Horrors.GetHorrorMovieByDirector
{
    public class GetHorrorMovieByDirectorQueryHandler : IRequestHandler<GetHorrorMovieByDirectorQuery, List<Movie>>
    {
        private readonly IMovieRepository _movieRepository;
        public GetHorrorMovieByDirectorQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<List<Movie>> Handle(GetHorrorMovieByDirectorQuery request, CancellationToken cancellationToken)
        {
            var movies = await _movieRepository.GetByDirectorAsync(request.Director);

            var horrorMovies = movies
            .Where(m => m.GetType() == typeof(Horror))
            .ToList();

            return horrorMovies;
        }
    }
}

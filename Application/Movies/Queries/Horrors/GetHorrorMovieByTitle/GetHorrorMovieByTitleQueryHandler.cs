using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.Movies.Queries.Horrors.GetHorrorMovieByTitle
{
    public class GetHorrorMovieByTitleQueryHandler : IRequestHandler<GetHorrorMovieByTitleQuery, List<Movie>>
    {
        private readonly IMovieRepository _movieRepository;
        public GetHorrorMovieByTitleQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<List<Movie>> Handle(GetHorrorMovieByTitleQuery request, CancellationToken cancellationToken)
        {
            var movies = await _movieRepository.GetByTitleAsync(request.Title);

            var horrorMovies = movies
            .Where(m => m.GetType() == typeof(Horror))
            .ToList();

            return horrorMovies;
        }
    }
}

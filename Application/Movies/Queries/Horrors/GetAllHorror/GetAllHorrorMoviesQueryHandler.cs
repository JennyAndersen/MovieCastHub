using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;


namespace Application.Movies.Queries.Horrors.GetAllHorror
{
    public class GetAllHorrorMoviesQueryHandler : IRequestHandler<GetAllHorrorMoviesQuery, List<Horror>>
    {
        private readonly IMovieRepository _movieRepository;

        public GetAllHorrorMoviesQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        async Task<List<Horror>> IRequestHandler<GetAllHorrorMoviesQuery, List<Horror>>.Handle(GetAllHorrorMoviesQuery request, CancellationToken cancellationToken)
        {
            List<Horror> allHorrorMovies = await _movieRepository.GetAllHorrorsMoviesAsync();
            return allHorrorMovies;
        }
    }
}

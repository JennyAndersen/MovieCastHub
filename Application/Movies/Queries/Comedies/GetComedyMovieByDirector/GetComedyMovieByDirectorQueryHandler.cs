using Application.Exceptions;
using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.IdentityModel.Tokens;

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
            if (comedyMovies.IsNullOrEmpty())
            {
                throw new EntityNotFoundException("Comedy", "Director", request.Director);
            }

            return comedyMovies;
        }
    }
}

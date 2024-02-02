using Application.Exceptions;
using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace Application.Movies.Queries.Comedies.GetComedyMovieByTitle
{
    public class GetComedyMovieByTitleQueryHandler : IRequestHandler<GetComedyMovieByTitleQuery, List<Movie>>
    {
        private readonly IMovieRepository _movieRepository;
        public GetComedyMovieByTitleQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<List<Movie>> Handle(GetComedyMovieByTitleQuery request, CancellationToken cancellationToken)
        {
            var movies = await _movieRepository.GetByTitleAsync(request.Title);

            var comedyMovies = movies
            .Where(m => m.GetType() == typeof(Comedy))
            .ToList();
            if (comedyMovies.IsNullOrEmpty())
            {
                throw new EntityNotFoundException("comedy", "title", request.Title);
            }

            return comedyMovies;
        }
    }
}

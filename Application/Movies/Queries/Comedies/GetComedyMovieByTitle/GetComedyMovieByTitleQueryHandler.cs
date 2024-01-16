using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.Movies.Queries.Comedies.GetComedyMovieByTitle
{
    public class GetComedyMovieByTitleQueryHandler : IRequestHandler<GetComedyMovieByTitleQuery, Movie>
    {
        private readonly IMovieRepository _movieRepository;
        public GetComedyMovieByTitleQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Movie> Handle(GetComedyMovieByTitleQuery request, CancellationToken cancellationToken)
        {
            return await _movieRepository.GetByTitleAsync(request.Title);
        }
    }
}

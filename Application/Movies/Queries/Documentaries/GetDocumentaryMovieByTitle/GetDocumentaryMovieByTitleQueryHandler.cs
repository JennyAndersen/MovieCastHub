using Application.Exceptions;
using Domain.Models;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace Application.Movies.Queries.Documentaries.GetDocumentaryMovieByTitle
{
    public class GetDocumentaryMovieByTitleQueryHandler : IRequestHandler<GetDocumentaryMovieByTitleQuery, List<Movie>>
    {
        private readonly IMovieRepository _movieRepository;
        public GetDocumentaryMovieByTitleQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<List<Movie>> Handle(GetDocumentaryMovieByTitleQuery request, CancellationToken cancellationToken)
        {
            var movies = await _movieRepository.GetByTitleAsync(request.Title);

            var documentaryMovies = movies
            .Where(m => m.GetType() == typeof(Documentary))
            .ToList();
            if (documentaryMovies.IsNullOrEmpty())
            {
                throw new EntityNotFoundException("documentary", "title", request.Title);
            }

            return documentaryMovies;
        }
    }
}
